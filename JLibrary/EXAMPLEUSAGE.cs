using System;
using InjectionLibrary;

namespace JLibrary
{
    class EXAMPLEUSAGE
    {
        public void Inject(int pID, Byte[] dllbytes)
        {
            InjectionMethod method = InjectionMethod.Create(InjectionMethodType.Standard); //InjectionMethodType.Standard //InjectionMethodType.ManualMap //InjectionMethodType.ThreadHijack
            IntPtr zero = IntPtr.Zero;
            using (PortableExecutable.PortableExecutable executable = new PortableExecutable.PortableExecutable(dllbytes))
            {
                zero = method.Inject(executable, pID);
            }
            if (zero != IntPtr.Zero)
            {
                //BAIL HERE - ERROR
            }
            else if (method.GetLastError() != null)
            {
                //ERROR OCCURED
                System.Windows.Forms.MessageBox.Show(method.GetLastError().Message);
            }
            //SUCCESS
        }
    }
}
