using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBountyHunter.Extras
{
    public class listaFugitivos
    {
        public List<Models.mFugitivos> ocFugitivos;

        public listaFugitivos()
        {
            ocFugitivos = new List<Models.mFugitivos>();
            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Armando Olmos"
            });
            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Carlos Martinez"
            });
            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Oscar Ruesga"
            });
            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Jorge Valadez"
            });
            ocFugitivos.Add(new Models.mFugitivos
            {
                Name = "Guillermo Ortega"
            });
        }
    }
}
