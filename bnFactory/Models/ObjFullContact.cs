using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Factory.Exceptions;

namespace Factory.Models
{
    public class ObjFullContact
    {
        public EntContacts entContact {get; private set;}
        public List<EntPhoneNumbers> lstPhoneNumber {get; private set;}
        public EntContactDetails entContactDetails {get; private set;}
        public List<EntAddresses> lstAddresses {get; private set;}

        public string jsonString {get; private set;}

        public ObjFullContact (EntContacts contact)
        {
            entContact = contact;
            ToJson();
        }
        public ObjFullContact(EntContacts contact, EntPhoneNumbers phoneNumber)
        {
            entContact = contact;
            lstPhoneNumber= new List<EntPhoneNumbers>();
            lstPhoneNumber.Add(phoneNumber);
            ToJson();
        }
        public ObjFullContact(EntContacts contact, List<EntPhoneNumbers> lstNumbers)
        {
            entContact = contact;
            lstPhoneNumber= new List<EntPhoneNumbers>();
            lstPhoneNumber.AddRange(lstNumbers);
            ToJson();
        }
        public ObjFullContact(EntContacts contact, EntContactDetails details)
        {
            entContact = contact;
            entContactDetails = details;
            ToJson();
        }
        public ObjFullContact(EntContacts contact, EntContactDetails details, EntAddresses address)
        {
            entContact = contact;
            entContactDetails = details;
            lstAddresses = new List<EntAddresses>();
            lstAddresses.Add(address);
            ToJson();
        }
        public ObjFullContact(EntContacts contact, EntContactDetails details, List<EntAddresses> lstAddresses)
        {
            entContact = contact;
            entContactDetails = details;
            lstAddresses = new List<EntAddresses>();
            lstAddresses.AddRange(lstAddresses);
            ToJson();
        }
        public ObjFullContact(EntContacts contact, EntContactDetails details, List<EntAddresses> lstAddresses, List<EntPhoneNumbers> lstNumbers)
        {
            entContact = contact;
            entContactDetails = details;
            lstAddresses = new List<EntAddresses>();
            lstAddresses.AddRange(lstAddresses);
            lstPhoneNumber= new List<EntPhoneNumbers>();
            lstPhoneNumber.AddRange(lstNumbers);
            ToJson();
        }

        public ObjFullContact(string jsonStream)
        {
            jsonString = jsonString;
            FromJson();
        }

        internal void ToJson()
        {
            
            var strEntContact =         entContact!=null        ? JsonConvert.SerializeObject(entContact)       : "{}";
            var strEntContactDetails =  entContactDetails!=null ? JsonConvert.SerializeObject(entContactDetails): "{}";
            var strListAddresses =      lstAddresses!=null      ? JsonConvert.SerializeObject(lstAddresses)     : "[{}]";
            var strListNumbers =        lstPhoneNumber!=null    ? JsonConvert.SerializeObject(lstPhoneNumber)   : "[{}]";

            jsonString = "{\"EntContacts\":"+strEntContact+
                            ",\"EntContactDetails\":"+strEntContactDetails+
                            ",\"lstAddresses\":"+strListAddresses+
                            ",\"lstPhoneNumbers\":"+strListNumbers+
                            "}";
        }
        internal void FromJson()
        {
            lstAddresses = new List<EntAddresses>();
            lstPhoneNumber= new List<EntPhoneNumbers>();

            JObject jsonObject = JObject.Parse(jsonString);
            
            
            var _entContact = jsonObject.SelectToken("EntContacts");
            var _entContactDetails = jsonObject.SelectToken("EntContactDetails");
            var _lstAddresses = (JArray)jsonObject.SelectToken("lstAddresses");
            var _lstPhoneNumbers = (JArray)jsonObject.SelectToken("lstPhoneNumbers");

            try
            {
                entContact = JsonConvert.DeserializeObject<EntContacts>(_entContact.Root.ToString());
                entContactDetails = JsonConvert.DeserializeObject<EntContactDetails>(_entContactDetails.Root.ToString());
                foreach(var item in _lstAddresses)
                {
                    var _entAddress = JsonConvert.SerializeObject(item.SelectToken("EntAddresses"));
                    lstAddresses.Add(JsonConvert.DeserializeObject<EntAddresses>(_entAddress));
                }
                foreach(var item in _lstPhoneNumbers)
                {
                    var _entPhoneNumber = JsonConvert.SerializeObject(item.SelectToken("EntPhoneNumbers"));
                    lstPhoneNumber.Add(JsonConvert.DeserializeObject<EntPhoneNumbers>(_entPhoneNumber));
                }
            }
            catch (JsonException jEx)
            {
                //bringing to standard excpetions to ease the process for the API
                throw new InvalidDataException(jEx.Message, jEx.InnerException);
            }
            catch 
            {
                var stackTrace = new System.Diagnostics.StackTrace();
                throw new System.Exception("There was an error transforming the json in to objects, please check the data.\r\n"+stackTrace.ToString());
            }
        }
    }
}