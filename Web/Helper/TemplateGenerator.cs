using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Helper
{
    public static class TemplateGenerator
    {
        public static string GetPDFHTMLString()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(@"

<!DOCTYPE html>
<html>

<head>
   
    <title> Document </title>
</head>

<body>



    <p> The QPro™ Virtex® family delivers high - performance, high - capacity programmable logic solutions.Dramatic
        increases in silicon efficiency result from optimizing the new architecture for place - and - route efficiency and
        exploiting an aggressive 5 - layer - metal 0.22 µm CMOS process.These advances make QPro Virtex FPGAs powerful and
        flexible alternatives to mask - programmed gate arrays.The Virtex radiation - hardened family comprises the three
        members shown in Table 1.</p>
    <p> Building on experience gained from previous generations of FPGAs, the Virtex family represents a revolutionary
        step forward in programmable logic design.Combining a wide variety of programmable system features, a rich
        hierarchy of fast, flexible interconnect resources, and advanced process technology, the QPro Virtex family
        delivers a high - speed and high - capacity programmable logic solution that enhances design flexibility while
    
            reducing time - to - market.</p>
    
        <p> Refer to the Virtex 2.5V FPGA commercial data sheet at http://www.xilinx.com/support/documentation/virtex.htm for
            more information on device architecture and timing specifications.</p>
    



        <p> Table 1: QPro Virtex FPGA Radiation-Hardened FPGA Family Members </p>


           DeviceSystem GatesCLB ArrayLogic CellsMaximum
           Available I / OBlock RAM BitsMaximum Select RAM
    BitsXQVR300322,97032x486,91216265,53698,304XQVR600661,11148x7215,55216298,304221,184XQVR10001,124,02264x9627,648404131,072393,216

</body>

</html>

            ");

            return sb.ToString();
        }
    }
}
