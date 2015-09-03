using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RC.Soul
{
    public class Soul
    {
        public static Soul Signil
        {
            get
            {
                if (sig == null)
                    return (sig = new Soul());
                else
                    return sig;
            }
        }
        private static Soul sig;
        public UInt64 Mana;
        public virtual void Signal(int i)
        {

        }
    }
    public static class Constat
    {
        public const ulong Stone = 0x001;               // Камень
        public const ulong Air = 0x002;                 // Ветер
        public const ulong Fire = 0x003;                // Огнь
        public const ulong Auqa = 0x004;                // Вода
        // Действия
        public const ulong Infernum = 0xe10;            // Действие: Воспламенения
        public const ulong Shear = 0xe11;               // Действие: Сдвиг
        public const ulong Splitting = 0xe12;           // Действие: Расщепление
        public const ulong Comperss = 0xe13;            // Действие: Сжатие
        // Направления
        public const ulong Forward = 0x2f1;             // Направление: Вперёд
        public const ulong Back = 0x2f2;                // Направление: Назад
        public const ulong Left = 0x2f3;                // Направление: Влево
        public const ulong Right = 0x2f4;               // Направление: Вправо
        public const ulong Down = 0x2f5;                // Направление: Вниз
        public const ulong Up = 0x2f6;  	            // Направление: Вверх
    }

}
namespace RC.Core
{
    public class Aix
    { }
    public class CAD
    {
        public virtual void Input(CAD cstingDevice)
        { }
        public virtual void Error(CAD cstingDevice, Aix crystall)
        { }
        public virtual void Message(CAD cstingDevice, int sig)
        { }
        public void Rejection(Aix a)
        { }
        public void Cast(ulong u)
        { }
        public void Mixing(ulong u)
        { }
        public void Impuls(ulong u)
        { }
    }
    public static class Constat
    { }
    public static class Tools
    {
        public static ulong MathMana(ulong uid)
        {
            return uid;
        }
        public static ulong MathManaMix(int count, ulong mass)
        {
            return mass;
        }
        public static ulong MathManaImpuls(ulong mass)
        {
            return mass;
        }
        public static ulong MathMass(params ulong[] uid)
        {
            return uid[0];
        }
    }
}


namespace Soul.Core
{
    using RC.Core;
    using RC.Soul;
    using static RC.Soul.Constat;
    using static RC.Core.Constat;
    using static RC.Core.Tools;
    public class Axi_Gen02 : CAD
    {
        public Axi_Gen02() : base()
        { }
        public override void Input(CAD cstingDevice)
        {
            if (Soul.Signil.Mana >= (MathMana(Stone) + MathMana(Fire) + MathManaMix(2, MathMass(Stone, Fire)) + MathManaImpuls(MathMass(Stone, Fire))))
            {
                cstingDevice.Cast(Stone);
                cstingDevice.Cast(Fire);
                cstingDevice.Mixing(Infernum);
                cstingDevice.Impuls(Forward);
            }
            base.Input(cstingDevice);
        }
        public override void Error(CAD cstingDevice, Aix crystall)
        {
            cstingDevice.Rejection(crystall);
            base.Error(cstingDevice, crystall);
        }
        public override void Message(CAD cstingDevice, int sig)
        {
            Soul.Signil.Signal(sig);
            base.Message(cstingDevice, sig);
        }
    }
}
