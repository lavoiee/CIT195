using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    interface ISpeak {

        List<string> Messages { get; set; }
        string Spreak();

    }
}
