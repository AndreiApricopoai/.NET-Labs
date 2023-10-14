using InheritanceSample;

namespace Lab1
{
    public class Utilizator
    {
        public string Nume { get; set; }
        public string Email { get; set; }
        public string NumarTelefon { get; set; }
        public string DeviceToken { get; set; } 
    }

    public class ManagerNotificari
    {
        private readonly List<INotificator> _notificatori;

        public ManagerNotificari()
        {
            _notificatori = new List<INotificator>
        {
            new NotificareEmail(),
            new NotificareSMS(),
            new NotificarePush()
        };
        }

        public void TrimiteNotificariLaToti(string mesaj, List<Utilizator> utilizatori)
        {
            foreach (var utilizator in utilizatori)
            {
                foreach (var notificator in _notificatori)
                {
                    notificator.TrimiteNotificare(mesaj, utilizator);
                }
            }
        }
    }


    public interface INotificator
    {
        void TrimiteNotificare(string mesaj, Utilizator utilizator);
    }

    public class NotificareEmail : INotificator
    {
        public void TrimiteNotificare(string mesaj, Utilizator utilizator)
        {
            Console.WriteLine($"Trimit email către {utilizator.Email} cu mesajul: {mesaj}");
        }
    }

    public class NotificareSMS : INotificator
    {
        public void TrimiteNotificare(string mesaj, Utilizator utilizator)
        {
            Console.WriteLine($"Trimit SMS către {utilizator.NumarTelefon} cu mesajul: {mesaj}");
        }
    }

    public class NotificarePush : INotificator
    {
        public void TrimiteNotificare(string mesaj, Utilizator utilizator)
        {
            Console.WriteLine($"Trimit notificare push către {utilizator.DeviceToken} cu mesajul: {mesaj}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var utilizatori = new List<Utilizator>
            {
                new Utilizator { Nume = "Ion", Email = "ion@email.com", NumarTelefon = "1234567890", DeviceToken = "token1" },
                new Utilizator { Nume = "Ana", Email = "ana@email.com", NumarTelefon = "0987654321", DeviceToken = "token2" }
            };

            var managerNotificari = new ManagerNotificari();
            managerNotificari.TrimiteNotificariLaToti("Ai un mesaj nou!", utilizatori);
        }
    }
}