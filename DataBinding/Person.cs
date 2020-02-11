using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WPFDemo.Annotations;

namespace WPFDemo.DataBinding {
    public class Person{

        public Person() {
        }

        public string Name { get; set; }

        public int Age { set; get; }
    }
}
