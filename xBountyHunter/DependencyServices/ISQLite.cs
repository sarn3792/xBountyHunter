﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace xBountyHunter.DependencyServices
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
