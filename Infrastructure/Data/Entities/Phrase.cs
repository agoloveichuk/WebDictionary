﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Phrase
    {
        public int PhraseId { get; set; }
        public int? DictionaryId { get; set; }
        public string EnPhrase { get; set; }
        public string UaPhrase { get; set; }
        public string Definition { get; set; }
        public Dictionary Dictionary { get; set; }
    }
}
