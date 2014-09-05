using MessagingTest.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

#region MessageStructs

public struct MessageRequest
{
    [JsonProperty("startTime")]
    public DateTime StartTime { get; set; }

    [JsonProperty("endTime")]
    public DateTime EndTime { get; set; }

    [JsonProperty("messageIds")]
    public List<long> MessageIds { get; set; }

    [JsonProperty("all")]
    public bool All { get; set; }

    [JsonProperty("unreadOnly")]
    public bool UnreadOnly { get; set; }
}

public struct MessageRequestResponse
{
    [JsonProperty("isValid", Required = Required.Always)]
    public bool IsValid { get; set; }

    [JsonProperty("statusMsg")]
    public string StatusMsg { get; set; }

    [JsonProperty("messages", Required = Required.AllowNull)]
    public List<MessageBodyStruct> Messages { get; set; }
}

public struct MessageBodyStruct
{
    [JsonProperty("sender")]
    public string Sender { get; set; }

    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonProperty("conversationId")]
    public long Conversation { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }
}

public struct ContactRequest
{
    [JsonProperty("sender")]
    public string Sender { get; set; }

    [JsonProperty("recieverName", NullValueHandling = NullValueHandling.Ignore)]
    public string RecieverName { get; set; }

    [JsonProperty("recieverEmail", NullValueHandling=NullValueHandling.Ignore)]
    public string RecieverEmail { get; set; }

    [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
    public ContactRequestStatus Status { get; set; }
}

public struct CurrentStatus
{
    public int UnreadCount { get; set; }

    public List<ContactRequest> PendingContacts { get; set; }

}

#endregion // MessageStructs
