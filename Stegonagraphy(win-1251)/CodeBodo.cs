using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Word5
{
    class CodeBodo
    {
        public string binaryCode { get; set; }

        public string Simbol { get; set; }

        public List<CodeBodo> myList { get; set; }

        public void GetList()
        {
            myList = new List<CodeBodo>
            {
                new CodeBodo{binaryCode="00011",Simbol="а"},
                new CodeBodo{binaryCode="11001",Simbol="б"},
                new CodeBodo{binaryCode="01110",Simbol="ц"},
                new CodeBodo{binaryCode="01001",Simbol="д"},
                new CodeBodo{binaryCode="00001",Simbol="е"},
                new CodeBodo{binaryCode="01101",Simbol="ф"},
                new CodeBodo{binaryCode="11010",Simbol="г"},
                new CodeBodo{binaryCode="10100",Simbol="ч"},
                new CodeBodo{binaryCode="00110",Simbol="и"},
                new CodeBodo{binaryCode="01011",Simbol="й"},
                new CodeBodo{binaryCode="01111",Simbol="к"},
                new CodeBodo{binaryCode="10010",Simbol="л"},
                new CodeBodo{binaryCode="11100",Simbol="м"},
                new CodeBodo{binaryCode="01100",Simbol="н"},
                new CodeBodo{binaryCode="11000",Simbol="о"},
                new CodeBodo{binaryCode="10110",Simbol="п"},
                new CodeBodo{binaryCode="10111",Simbol="я"},
                new CodeBodo{binaryCode="01010",Simbol="р"},
                new CodeBodo{binaryCode="00101",Simbol="с"},
                new CodeBodo{binaryCode="10000",Simbol="т"},
                new CodeBodo{binaryCode="00111",Simbol="у"},
                new CodeBodo{binaryCode="11110",Simbol="ж"},
                new CodeBodo{binaryCode="10011",Simbol="в"},
                new CodeBodo{binaryCode="11101",Simbol="ь"},
                new CodeBodo{binaryCode="10101",Simbol="ы"},
                new CodeBodo{binaryCode="10001",Simbol="з"},
                new CodeBodo{binaryCode="00100",Simbol=" "},
                new CodeBodo{Simbol="00010",binaryCode=" "}
            };
        }
    }
}
