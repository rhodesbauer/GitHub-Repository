using System;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public class BasicModel : Interfaces.IEntity
    {
        [Required]
        public DateTime dtCreation      { get; set; }
        public DateTime? dtLastChange   { get; set; }
        [Required]
        public string userIDCreation    { get; set; }
        public string userIDLastChange  { get; set; }

        public BasicModel(string userID)
        {
            this.dtLastChange = System.DateTime.Now;
            this.userIDLastChange = userID;
        }

        /// <summary>
        /// Available for compatibility with entity framework
        /// </summary>
        public BasicModel(){}


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
                disposedValue = true;
        }

        public void Dispose() => Dispose(true);
        #endregion

    }
}