using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Identity.DTOs.Response
{
    public class Response<T>
    {
        public ICollection<string> Errors { get; private set; }
        public bool Succedeed { get; private set; }
        public T Result { get; set; }

        public Response()
        {
            Errors = new List<string>();
            Succedeed = true;
        }

        public void AddErrors(ICollection<string> errors)
        {
            Succedeed = false;
            foreach (var error in errors)
            {
                Errors.Add(error);
            }
        }
    }
}
