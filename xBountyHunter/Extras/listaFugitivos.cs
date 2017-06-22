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
        private databaseManager db = new databaseManager();
        public listaFugitivos()
        {
            
        }

        public List<Models.mFugitivos> getFugitivos()
        {
            ocFugitivos = db.selectNoCaptured();
            return ocFugitivos;
        }

        public List<Models.mFugitivos> getCapturados()
        {
            ocFugitivos = db.selectCaptured();
            return ocFugitivos;
        }
    }
}
