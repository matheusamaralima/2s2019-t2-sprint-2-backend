﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Domains
{
    public class Favoritos
    {
        public int IdUsuario { get; set; }
        public Usuarios Usuario { get; set; }

        public int IdMidia { get; set; }
        public Midias Midia { get; set; }
    }
}
