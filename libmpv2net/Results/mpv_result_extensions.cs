using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public static class mpv_result_extensions
    {
        public static void ThrowOnFail(
            this mpv_result result, string command, params object[] args)
        {
            if (result.result_code >= 0)
                return;

            var argStringBuilder = new StringBuilder();
            foreach (var item in args)
            {
                if (item == null)
                    argStringBuilder.Append("[null], ");
                else
                    argStringBuilder.Append(item.ToString()).Append(", ");
            }

            var argString = argStringBuilder.ToString();

            if (Enum.IsDefined(typeof(mpv_error), result.result_code))
            {
                var error = (mpv_error)result.result_code;
                throw new MpvCallException(error, command, argString);
            }
            else
            {
                throw new MpvCallException(result.result_code, 
                    command, argString);
            }
        }
    }
}
