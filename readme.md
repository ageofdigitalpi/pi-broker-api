#Event Broker Web API#

##Notes##

Each instance uses a UUID/GUID (int128, random). This identifies the web application making the request.

To listen to notifications an application registers as its instance, its accessing user and for a given event ID. The web application then polls based on the instance ID. The application should unregister at the end of a session, although potentially after time X without polling the notifications should be purged.

To notify an application sends a notify request with its instance ID, given event ID and data. The server then creates notifications for all 

##Register##
_http(s)://[host]/api/broker/register_

```
{
    
    "UserId": "H07001000",

    "InstanceId": "D7756D14-8026-4B17-B4F3-DDFCEE8F81AD",

    "EventConstant": "NEW_CALL_RECEIVED",

    "Action": "functionToCall"

}
```

##Poll##
_http(s)://[host]/api/broker/poll_

```
{
    
    "InstanceId": "D7756D14-8026-4B17-B4F3-DDFCEE8F81AD"

}
```

##Unregister##
_http(s)://[host]/api/broker/unregister_

```
{
    
    "InstanceId": "D7756D14-8026-4B17-B4F3-DDFCEE8F81AD",

    "EventConstant": "NEW_CALL_RECEIVED"
}
```

##Notify##
_http(s)://[host]/api/broker/notify_

```
{
    
    "UserId": "H07001000",

    "InstanceId": "E7756D14-8026-4B17-B4F3-DDFCEE8F81AD",

    "EventConstant": "NEW_CALL_RECEIVED",

    "Data": "ctiData"

}
```
