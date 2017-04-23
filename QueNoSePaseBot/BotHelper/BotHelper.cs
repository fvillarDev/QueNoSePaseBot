using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.Bot.Connector;
using QueNoSePase.API;
using QueNoSePase.API.Models;
using QueNoSePase.API.Controllers;
using Newtonsoft.Json;

namespace QueNoSePaseBot.BotHelper
{
    internal class BotHelper
    {
        public static string ParseMessage(Activity message, HorariosController horariosController)
        {
            try
            {
                var msg = message.Text;
                var msgLower = msg.ToLower();

                if (msg.Trim().ToLower().StartsWith("hola"))
                    return string.Format(GetSaludoRandom(),message.From.Name);

                if (msg.Trim().ToLower().StartsWith("gracias"))
                    return string.Format(GetGraciasRandom(), message.From.Name);

                if (msg.Trim().ToLower().Equals("/start"))
                {
                    return "Gracias por utilizar el servicio. Envía el número de parada y te devolveré los horarios de llegada!";
                }                    

                // buscar parada
                if (msgLower.StartsWith("c") && msgLower.Substring(0, 1).Equals("c"))
                {
                    var splitted = msgLower.Split(' ');
                    //si comienza con c y nada mas, asume busqueda por todos
                    if (splitted.Length == 1)
                    {
                        //return "Envía: **Número de Parada** **Linea** para conocer el arribo esa línea en esa parada.";
                        var jsonH = horariosController.Get(splitted[0]);
                        var horarios = JsonConvert.DeserializeObject<List<QueNoSePase.API.Models.Horario>>(jsonH);

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Parada: " + splitted[0].ToUpper() + " - Todos - ");
                        sb.AppendLine(Environment.NewLine);

                        foreach (var item in horarios)
                        {
                            Horario horario = new Horario();
                            horario.Linea = item.Linea;
                            horario.Barrio = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Direccion.ToLower());
                            horario.Llegando = item.Llegando;
                            horario.Minutos = item.Minutos;
                            sb.AppendLine(horario.ToString());
                            sb.AppendLine(Environment.NewLine);
                        }
                        
                        return sb.ToString();

                        //return GetNoMsgRandom();
                    }
                    if (splitted.Length > 1)
                    {
                        return "Envía: **Número de Parada** para conocer el arribo esa línea en esa parada.";

                        //if (linea.ToLower().Equals("todos") || linea.ToLower().Equals("todas"))
                        //{
                        //    var list = HttpHelper.GetHorarioTodos(parada);
                        //    if (list != null)
                        //    {
                        //        return list;
                        //    }

                        //    return GetNoMsgRandom();
                        //}

                        //return "Pronto implementaremos más funciones. Disculpe las molestias.";
                    }
                    return GetNoMsgRandom();
                }

                if (msg.Trim().ToLower().Equals("ayuda") || msg.Trim().ToLower().Equals("opciones") || msg.Trim().ToLower().Equals("opcion"))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(
                        "Envía: **Número de Parada** para conocer el arribo esa línea en esa parada.");
                    sb.AppendLine("");
                    sb.AppendLine("Ejemplo:");
                    sb.AppendLine("  C1324");
                    return sb.ToString();
                }

                //if (msgLower.StartsWith("parada") || msgLower.StartsWith("cercana"))
                //{
                //    var splitted = msgLower.Split(':');
                //    if (splitted.Length > 1)
                //    {
                //        string posicion = splitted[1].TrimStart().TrimEnd().Trim();
                //        var pos = posicion.Split(',');
                //        var parameters = new NameValueCollection
                //           {
                //               { "funcion", "paradasCercanas" },
                //               { "userId", Constants.USER_ID },
                //               { "uWeb", Constants.USUARIO },
                //               { "cWeb", Constants.CLAVE },
                //               { "latitud", pos[0].Replace(".", ",") },
                //               { "longitud", pos[1].Replace(".", ",") }
                //           };
                //        var res = Helper.HttpPost(parameters);
                //        var paradas = Helper.ParseParadasCercanasAspx(res);

                //        int index = 0;
                //        StringBuilder sb = new StringBuilder();
                //        string baseurl = "http://map.quenosepase.com.ar?user=" + pos[0] + ";" + pos[1] + (paradas.Count > 0 ? "&paradas=" : "");
                //        foreach (ParadaCercana cercana in paradas)
                //        {
                //            if (cercana.Parada == null) continue;

                //            var data = index + ",Lineas " + string.Join("-", cercana.Lineas) + "," +
                //                      cercana.Parada.NumeroParada + "," + cercana.Parada.Latitud.Replace(",", ".") + ";" + cercana.Parada.Longitud.Replace(",", ".");
                //            sb.Append(data + "|");
                //            index++;
                //        }
                //        return baseurl + sb.ToString();
                //        //return "[Ver Paradas Cercanas](" + url + ")";
                //    }
                //}
                
                return GetNoMsgRandom();
            }
            catch (Exception ex)
            {
                LogHelper.LogAsync(ex, "MessagesController_BotHelper", (message != null ? message.Text : ""), (message != null ? message.From.Name : ""));
                return GetNoMsgRandom();
            }
        }

        private static string GetSaludoRandom()
        {
            return Models.Constants.SALUDOS[new Random().Next(0, Models.Constants.SALUDOS.Count)];
        }

        private static string GetGraciasRandom()
        {
            return Models.Constants.GRACIAS[new Random().Next(0, Models.Constants.SALUDOS.Count)];
        }

        private static string GetNoMsgRandom()
        {
            return Models.Constants.NO_MSG[new Random().Next(0, Models.Constants.SALUDOS.Count)];
        }
    }

    internal class HttpHelper
    {
        private static string USER_ID = "7fb167c1-0b3f-4abb-9408-519e2d3576d1";
        private static string USUARIO = "usuarioefisat";
        private static string CLAVE = "efisat";
        private static int PAIS = 1;
        private static int PROVINCIA = 17;
        private static int CIUDAD = 20;

        public static string GetHorarioTodos(string parada, bool useDebug = false)
        {
            try
            {
                var a = new ServicioWebHorariosProximos.ServicioWebHorariosProximos();
                var res = a.RecuperarHorarioCuandoLlegaDosAndroid(parada, USER_ID, "TODOS", USUARIO, CLAVE, "-1");
                var lista = new List<Horario>();
                if (res.StartsWith("0|"))
                {
                    if (res.Contains("Sin datos"))
                        return "*No se encontraron horarios para esta parada*";

                    var resAux = res.Split('|');
                    if (resAux.Length < 2) return null;

                    var sp = resAux[1].Split(new[] { "//" }, StringSplitOptions.None);

                    foreach (string s in sp)
                    {
                        if (string.IsNullOrEmpty(s)) continue;

                        var data = s.Split(',');
                        if (data.Length > 0)
                        {
                            Horario horario = new Horario();
                            horario.Linea = data[0];
                            horario.Barrio = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data[1].ToLower());
                            if (data[2] == "0")
                            {
                                horario.Llegando = true;
                                horario.Minutos = 0;
                            }
                            else
                                horario.Minutos = Int32.Parse(data[2]);

                            lista.Add(horario);
                        }
                    }
                }

                var listaOrdered = lista.OrderBy(item => item.Minutos);

                //ServicioWebHorariosProximos a = new ServicioWebHorariosProximos();
                //var res = a.RecuperarHorarioCuandoLlegaAndroid(parada, "7fb167c1-0b3f-4abb-9408-519e2d3576d1", "TODOS",
                //    "usuarioefisat", "efisat", "-1");
                //var lista = Parser.Parse(res);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Parada: " + parada.ToUpper() + " - Todos - ");
                sb.AppendLine(Environment.NewLine);
                foreach (Horario horario in listaOrdered)
                {
                    sb.AppendLine(horario.ToString());
                    sb.AppendLine(Environment.NewLine);
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                if(useDebug)
                    return ex.Message;
                return null;
            }
        }
    }

    internal class Parser
    {
        public static List<Horario> Parse(string text)
        {
            var resAux = text.Split('|');
            if (resAux.Length < 2) return null;

            var sp = resAux[1].Split(new[] { "//" }, StringSplitOptions.None);

            var banned = new List<string>();
            banned.Add("A");
            banned.Add("ARRIBANDO");

            var horarios = new List<Horario>();

            Regex regex = new Regex(@"\b([A-Z]+)\b");
            foreach (string s in sp)
            {
                if (string.IsNullOrEmpty(s)) continue;

                var horario = new Horario();

                var linea = s.Substring(0, 3).Trim();
                var hacia = "";
                var matches = regex.Matches(s);
                foreach (Match match in matches)
                {
                    if (!banned.Contains(match.Value))
                    {
                        hacia += match.Value + " ";
                    }
                    else if (match.Value == "ARRIBANDO")
                    {
                        horario.Llegando = true;
                    }
                }

                horario.Linea = linea;
                horario.Barrio = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(hacia.ToLower());
                horario.Barrio = horario.Barrio.TrimEnd();

                var regexMin = new Regex(@"( [0-9]+ [a-z]+)");
                var matchesMin = regexMin.Matches(s);
                foreach (Match match in matchesMin)
                {
                    //horario.Minutos = match.Value;
                }
                horarios.Add(horario);
            }

            //var json = JsonConvert.SerializeObject(horarios);
            return horarios;
        }
    }

    internal class Horario
    {
        public string Linea { get; set; }
        public string Barrio { get; set; }
        private string MinutosText
        {
            get
            {
                return Minutos + " min";
            }
        }
        public int Minutos { get; set; }
        public bool Llegando { get; set; }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append("Linea: **" + Linea + "**");
            s.Append(", " + Barrio);
            if (Llegando)
                s.Append(", **Llegando**");
            else
                s.Append(", en **" + MinutosText + "**");

            return s.ToString();
        }
    }
}