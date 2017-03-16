using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitStand.Models
{
    public enum Status
    {
        Ok,
        Failed
    }

    public class Response
    {
        private bool _success;
        private Status _status;

        [JsonIgnore]
        public Status Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;

                if (string.IsNullOrEmpty(Message))
                {
                    if (_status == Status.Ok)
                    {
                        // Message = "Record updated.";
                    }
                    else if (_status == Status.Failed)
                    {
                        Message = "Failed to update the record.";
                    }
                }
            }
        }

        public string Message { get; set; }

        public object Extra { get; set; }

        public bool Success
        {
            get
            {
                return _success == false ? Status == Status.Ok : _success;
            }
            set
            {
                _success = value;
            }
        }

        public bool IsShowInFormItself { get; set; }
    }
}