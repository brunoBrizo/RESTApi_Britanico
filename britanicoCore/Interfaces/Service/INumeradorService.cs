﻿using britanicoCore.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace britanicoCore.Interfaces
{
    public interface INumeradorService
    {
        Task<Numerador> GetByNombre(int empId, string nombre);
        Task Insert(Numerador numerador);
        Task Update(Numerador numerador);
    }
}
