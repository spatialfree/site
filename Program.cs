using System;
using System.IO;
using Twilio;
using System.Net.Mail;
using Twilio.Rest.Api.V2010.Account;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;



return;

// string accountSid = Environment.GetEnvironmentVariable("AC65e8eb193a0f8a37dda5bfeaf7555cbd");
// string authToken = Environment.GetEnvironmentVariable("ad86263d584e9e385926c3b96e9ed3b2");

// TwilioClient.Init(accountSid, authToken);

// var msg = MessageResource.Create(
//   body: "This is the ship that made the Kessel Run in fourteen parsecs?",
//   from: new Twilio.Types.PhoneNumber("+15097015021"),
//   to: new Twilio.Types.PhoneNumber("+15097015021")
// );

// Console.WriteLine(msg.Sid);





// void EmailSMS() {
//   var message = new MailMessage();
//   message.From = new MailAddress("cadetmerchant@gmail.com");
//   message.To.Add(new MailAddress("5097015021@txt.att.net"));
//   message.Subject = "Test";
//   message.Body = "This is a test";
//   var client = new SmtpClient("smtp.gmail.com", 587);
//   client.UseDefaultCredentials = false;
//   client.EnableSsl = true;
//   client.Credentials = new System.Net.NetworkCredential("cadetmerchant@gmail.com", "kklrwgpbqlxjrolb");
//   client.Send(message);
// }



string txt = File.ReadAllText("students.txt");
Student[] students = new Student[64];
string[] stxt = txt.Split('_');
for (int i = 1; i < stxt.Length; i++)
{
  Student student = new Student();
  // get what comes after name: in the string
  string[] s = stxt[i].Split(':', '\n');
  for (int j = 0; j < s.Length; j++)
  {
    switch (s[j].Trim()) {
      case "name":
        student.name = s[j + 1].Trim('\'').Trim();
        break;
      case "day":
        student.day = int.Parse(s[j + 1].Trim());
        break;
      case "hour":
        student.hour = int.Parse(s[j + 1].Trim());
        break;
      case "sessions":
        student.sessions = int.Parse(s[j + 1].Trim());
        break;
      case "streak":
        student.streak = int.Parse(s[j + 1].Trim());
        break;
    }
  }
  students[i] = student;
}

while (true) {
  Console.Write("command: ");
  string[] cmd = Console.ReadLine().Split(' ');
  Console.Clear();
  switch (cmd[0]) {
    case "help":
      Console.WriteLine("exit - exit the program");
      Console.WriteLine("list - list all students");
      Console.WriteLine("add - add a student");
      Console.WriteLine("remove - remove a student");
      Console.WriteLine("edit - edit a student");
      break;
    case "list":
      for (int i = 0; i < students.Length; i++) {
        if (students[i] != null) {
          Console.WriteLine(students[i].name);
        }
      }
      break;
    case "add":
      Console.WriteLine("name day hour sessions streak");
      string[] s = Console.ReadLine().Split(' ');
      Student student = new Student(
        s[0],
        int.Parse(s[1]),
        int.Parse(s[2]),
        int.Parse(s[3]),
        int.Parse(s[4])
      );
      for (int i = 0; i < students.Length; i++) {
        if (students[i] == null) {
          students[i] = student;
          break;
        }
      }
      break;
    case "remove":
      if (cmd.Length == 1) {
        Console.WriteLine("name required");
        break;
      }
      for (int i = 0; i < students.Length; i++) {
        if (students[i] != null && students[i].name == cmd[1]) {
          students[i] = null;
          Console.WriteLine("removed " + cmd[1]);
          break;
        }
      }
      break;
    case "edit":
      if (cmd.Length == 1) {
        Console.WriteLine("name required");
        break;
      }
      for (int i = 0; i < students.Length; i++) {
        if (students[i] != null && students[i].name == cmd[1]) {
          Console.Clear();
          bool done = false;
          while (!done) {
            Console.WriteLine("name:"+students[i].name);
            Console.WriteLine("day:"+students[i].day);
            Console.WriteLine("hour:"+students[i].hour);
            Console.WriteLine("sessions:"+students[i].sessions);
            Console.WriteLine("streak:"+students[i].streak);
            Console.WriteLine("");
            Console.Write("edit: ");
            string[] edit = Console.ReadLine().Split(' ');
            switch (edit[0]) {
              case "miss":
                students[i].streak = Math.Min(0, students[i].streak - 1);
                if (students[i].streak < 0) { students[i].sessions--; }
                break;
              case "show":
                students[i].streak = Math.Max(1, students[i].streak + 1);
                if (students[i].streak % 4 != 0) { students[i].sessions--; }
                break;
              case "exit":
                done = true;
                break;
              default:
                Console.WriteLine("invalid edit");
                break;
            }
            Console.Clear();
          }
          break;
        }
      }
      break;
    case "exit":
      txt = "";
      for (int i = 0; i < students.Length; i++) {
        if (students[i] != null) {
          txt += "_\n";
          txt += "name:'" + students[i].name + "\n";
          txt += "day:" + students[i].day + "\n";
          txt += "hour:" + students[i].hour + "\n";
          txt += "sessions:" + students[i].sessions + "\n";
          txt += "streak:" + students[i].streak + "\n";
        }
      }
      File.WriteAllText("students.txt", txt);
      return;
    default:
      Console.WriteLine("invalid command");
      break;
  }
}


class Student
{
  public string name;
  public int day;
  public int hour;
  public int sessions;
  public int streak;
  
  public Student(string name = "", int day = 0, int hour = 0, int sessions = 0, int streak = 0)
  {
    this.name = name;
    this.day = day;
    this.hour = hour;
    this.sessions = sessions;
    this.streak = streak;
  }
}