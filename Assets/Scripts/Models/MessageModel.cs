using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace echoes.MVP.Models
{
    public class MessageModel
    {
        public string GUID;
        public string message;
        public string author;

        public MessageModel(string message, string author)
        {
            this.GUID = System.Guid.NewGuid().ToString();
            this.message = message;
            this.author = author;
        }
    }
}