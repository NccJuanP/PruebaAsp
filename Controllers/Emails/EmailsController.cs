using System.Text;
using System.Text.Json;
using prueba.Models;
namespace prueba.Controllers.Emails
{
    public class EmailsController
    {
        public async void CreateEmail(string StudentEmail, string StudentName, string TeacherEmail, string TeacherName, string Status, string CourseName)
        {
            string cuerpo = $"Felicidades {StudentName} ha quedado inscrito en el curso {CourseName} con el profesor {TeacherName}\nPara mayor informacion escribir al correo{TeacherEmail}\nLe recordamos que el curso se encuentra en estado de {Status}";

            //Url de la api
            string url = "https://api.mailersend.com/v1/email";

            //Credenciales de la api
            string Token = "mlsn.c2562e842d265e41064902366cca44e94edb210541c7bc906e9a6c24cf12db10";

            //Creacion de nuestra instancia que será el body de la api
            var email = new Email
            {
                from = new From
                {
                    email = "matriculas@trial-zr6ke4njee9gon12.mlsender.net"
                },
                to = new To[]{
                    new To{
                        email = StudentEmail
                        }
                },
                subject = $"Matricula realizada en el curso {CourseName}",
                text = cuerpo,
                html = cuerpo
            };

            //Serialización del objeto a json
            string jsonBody = JsonSerializer.Serialize(email);

            //Creacion de la peticion por medio de solicitud http
            using (HttpClient client = new HttpClient())
            {

                //Configuracion de los Headers
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                //Creacion de la peticion
                StringContent Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                //Envio de la peticion
                HttpResponseMessage response = await client.PostAsync(url, Content);

                //Verificacion de la respuesta
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Email enviado");
                }
                else
                {
                    Console.WriteLine("Error al enviar el email");
                }
            }
        }
    }
}