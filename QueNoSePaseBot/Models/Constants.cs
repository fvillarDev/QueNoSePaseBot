using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueNoSePaseBot.Models
{
    public class Constants
    {
        public static List<string> SALUDOS = new List<string>
        {
            "Buen día, {0}",
            "Hola {0}!",
            "Hola! {0}, no olvides mandar el *número de parada* para conocer los horarios!"
        };

        public static List<string> NO_MSG = new List<string>
        {
            "Mmm.. Disculpa no he entendido el mensaje. Envía **ayuda** para conocer más.",
            "Disculpe, no he podido procesar su consulta. Verifica que los datos sean correctos.",
            "Ups! Algo no ha estado bien. Envía **ayuda** para conocer más."
        };

        public static List<string> GRACIAS = new List<string>
        {
            "De nada, {0}",
            ":)  No hay problema {0}",
            "Gracias a tí por usar el sevicio"
        };
    }
}