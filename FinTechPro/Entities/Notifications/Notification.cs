using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notifications
{
    public class Notification
    {
        public Notification() {
            Notifications = new List<Notification>();
        }

        [NotMapped]
        public string Property { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notification> Notifications;
        public bool ValidatePropertyString (string valor, string nameProperty)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nameProperty))
            {
                Notifications.Add(new Notification()
                {
                    Message = "Campo Obrigatório",
                    Property = nameProperty
                });
                return false;
            }
            return true;

        }
        public bool ValidatePropertyInt(int valor, string nameProperty)
        {

            if (valor < 1 || string.IsNullOrWhiteSpace(nameProperty))
            {
                Notifications.Add(new Notification
                {
                    Message = "Campo Obrigatório",
                    Property = nameProperty
                });

                return false;
            }

            return true;

        }


    }
}
