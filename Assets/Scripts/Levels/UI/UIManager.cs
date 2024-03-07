using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotificationSettings
{
    public string notifText;
    public int notifShowTime;
    public float shownFor;

    public NotificationSettings(string text, int time)
    {
        notifText = text;
        notifShowTime = time;
        shownFor = 0.0f;
    }
}
public class UIManager : MonoBehaviour
{
    public TMP_Text messageText;
    [SerializeField] GameObject notificationUI;
    private List<NotificationSettings> topQueuedNotifs = new List<NotificationSettings>();

    void Start()
    {
        notificationUI.SetActive(false);    
    }

    void Update()
    {
        manageTopNotifications();        
    }

    private void manageTopNotifications(){
        if(topQueuedNotifs.Count > 0){
            notificationUI.SetActive(true);
            Color currentColor = messageText.color;
            currentColor.a = 1;
            messageText.color = currentColor;
            showTopNotification();
            
        } else {
            notificationUI.SetActive(false);
        }
    }
    public void addTopNotification(string notifText, int timeShow){
        NotificationSettings sett = new NotificationSettings(notifText, timeShow);
        topQueuedNotifs.Add(sett);
    }
    private void showTopNotification(){
        NotificationSettings ns = topQueuedNotifs.First();
        this.messageText.text = ns.notifText;
        ns.shownFor += Time.deltaTime;

        // Fading for the last x% of lifetime
        float x = 1-0.25f;
        if(ns.shownFor >= ns.notifShowTime*x){
            Color currentColor = messageText.color;
            currentColor.a = (ns.notifShowTime - ns.shownFor) / (ns.notifShowTime - ns.notifShowTime*x);
            messageText.color = currentColor;
        }

        if(ns.shownFor >= ns.notifShowTime){
            topQueuedNotifs.RemoveAt(0);
        }
    }
}
