using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Data.Encryption
{
    public class EncryptionConvertor : ValueConverter<string, string>
    {
        public EncryptionConvertor()
            : base(x => EncryptionHelper.Encrypt(x), x => EncryptionHelper.Decrypt(x))
        { }
    }
}
