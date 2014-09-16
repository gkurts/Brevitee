using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.BattleStickers.Business.Data
{
    public partial class PlayerTwoCharacterHealth: IHealth
    {
        #region IHealth Members

        public int Health
        {
            get
            {
                return this.Value.Value;
            }
            set
            {
                this.Value = value;
                this.Save();
            }
        }

        #endregion
    }
}
