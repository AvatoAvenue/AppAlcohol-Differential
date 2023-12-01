using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiempodeUnaCervezaDef
{
    
    class ProcesoDeCalculo
    {
        public void proceso()
        {
            Console.WriteLine(Informacion.eTiempo + Informacion.eModelo + Informacion.eCantidad);
            LlenadoCB llenado = new LlenadoCB();
            int cont=0;
            double funResultado, mililitrosAlcohol,gradosalcoholTotal, constanteK, constanteM, tiempo, gradosalcohol, mililitros;
            var cervezas = llenado.Get();
            cont = Informacion.eModelo;
            mililitros = cervezas.First(x => x.id == cont + 1).mililitros;
            Console.WriteLine(mililitros);
            gradosalcohol = cervezas.First(x => x.id == cont + 1 ).gradosalcohol;
            Console.WriteLine(gradosalcohol);
            tiempo = Convert.ToDouble(Informacion.eTiempo);
            Console.WriteLine(tiempo);
            mililitrosAlcohol = mililitros * gradosalcohol;
            gradosalcoholTotal = mililitrosAlcohol * Convert.ToDouble(Informacion.eCantidad);
            Console.WriteLine(gradosalcoholTotal);
            constanteM = (60 / 15) * gradosalcoholTotal;
            constanteK = ((Math.Log(0.01 / gradosalcoholTotal)) / (constanteM - 1));
            Console.WriteLine(constanteK);
            funResultado = gradosalcoholTotal * Math.Pow(Math.E,constanteK * tiempo);

            if (FRTP.FRTPR != 0)
            {
                FRTP.FRTPR = funResultado + FRTP.FRTPR;
            }
            else
            {
                FRTP.FRTPR = funResultado;
            }
            Console.WriteLine("Resultado mismo tiempo");
        }
        public void procesoOT()
        {
            Console.WriteLine(Informacion.eTiempo + Informacion.eModelo + Informacion.eCantidad);
            LlenadoCB llenado = new LlenadoCB();
            int cont = 0;
            double funResultado, mililitrosAlcohol, gradosalcoholTotal, constanteK, constanteM, tiempo, gradosalcohol, mililitros;
            var cervezas = llenado.Get();
            cont = Informacion.eModelo;
            mililitros = cervezas.First(x => x.id == cont + 1).mililitros;
            Console.WriteLine(mililitros);
            gradosalcohol = cervezas.First(x => x.id == cont + 1).gradosalcohol;
            Console.WriteLine(gradosalcohol);
            tiempo = Convert.ToDouble(Informacion.eTiempo);
            Console.WriteLine(tiempo);
            mililitrosAlcohol = mililitros * gradosalcohol;
            gradosalcoholTotal = mililitrosAlcohol * Convert.ToDouble(Informacion.eCantidad);
            Console.WriteLine(gradosalcoholTotal);
            constanteM = (60 / 15) * gradosalcoholTotal;
            constanteK = ((Math.Log(0.01 / gradosalcoholTotal)) / (constanteM - 1));
            Console.WriteLine(constanteK);
            funResultado = gradosalcoholTotal * Math.Pow(Math.E, constanteK * tiempo);
                FRTP.FRTPR = funResultado;
            Console.WriteLine("Resultado tiempo distinto");
        }
        public void impresionTotal()
        {
            MessageBox.Show("La cantidad de alcohol que tienes en el cuerpo es de " + FRTP.FRTPR.ToString("N2") + " mililitros en el minuto " + Informacion.eTiempo);
            MessageBox.Show("Todos los resultados son aproximados dada la naturaleza de los números decimales en el lenguaje");
        }

    }
}
