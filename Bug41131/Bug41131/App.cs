using Xamarin.Forms;

namespace Bug41131
{
    public class App : Application
    {
        public App ()
        {
            var listener = new System.Net.HttpListener ();
            listener.Prefixes.Add ("http://*:8080/");
            listener.Start ();
            var bytes = System.Text.Encoding.ASCII.GetBytes ("A Proof of Concept for Bug 41131");
            var context = listener.GetContext ();
            context.Response.OutputStream.Write (bytes, 0, bytes.Length);
            context.Response.Close ();
            listener.Close ();
        }
    }
}
