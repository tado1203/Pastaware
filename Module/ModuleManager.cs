using System.Collections.Generic;
using System.Linq;

public class ModuleManager
{
    public static List<Module> Modules = new List<Module>();

    public static void InitModules()
    {
        //visual
        Modules.Add(new ArrayList());
        Modules.Add(new CapsuleESP());
        Modules.Add(new Nametag());
        Modules.Add(new PlayerList());
        Modules.Add(new Notification());

        //movement
        Modules.Add(new Flight());
        Modules.Add(new Speed());

        //exploit
        Modules.Add(new Orbit());

        Modules = Modules.OrderByDescending(module => module.Name.Length).ToList();
    }
}