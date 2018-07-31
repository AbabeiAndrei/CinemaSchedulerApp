using System;
using System.Collections.Generic;

namespace CinemaScheduler.App.Models
{
    public class TimeOfDay : IEqualityComparer<TimeOfDay>, ICloneable, IComparable, IFormattable
    {
        #region Fields

        private int _hour;
        private int _minute;

        #endregion

        #region Properties

        public virtual int Hour
        {
            get => _hour;
            set
            {
                if(value < 0 || value > 23)
                    throw new ArgumentOutOfRangeException(nameof(Hour), "value must be in 0~23 interval");
                _hour = value;
            }
        }

        public virtual int Minute
        {
            get => _minute;
            set
            {
                if(value < 0 || value > 59)
                    throw new ArgumentOutOfRangeException(nameof(Minute), "value must be in 0~59 interval");
                _minute = value;
            }
        }

        protected virtual TimeSpan TimeSpan => TimeSpan.FromHours(Hour).Add(TimeSpan.FromMinutes(Minute));

        #endregion

        #region Constructors
        
        public TimeOfDay()
        {
        }
        
        public TimeOfDay(int hour, int minute)
                : this()
        {
            _hour = hour;
            _minute = minute;
        }

        #endregion

        #region Equality members

        protected virtual bool Equals(TimeOfDay other)
        {
            return _hour == other._hour && _minute == other._minute;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null) 
                return false;

            if (ReferenceEquals(this, obj)) 
                return true;

            return obj.GetType() == GetType() && Equals((TimeOfDay) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }

        #endregion

        #region Implementation of IComparable

        /// <inheritdoc />
        public virtual int CompareTo(object obj)
        {
            if (!(obj is TimeOfDay tod))
                return 1;

            if (Hour > tod.Hour)
                return 1;
            if (Hour < tod.Hour)
                return -1;
            if (Minute > tod.Minute)
                return 1;
            if (Minute < tod.Minute)
                return -1;
            return 0;
        }

        #endregion
        
        #region Implementation of ICloneable
        
        /// <inheritdoc />
        public virtual object Clone()
        {
            return new TimeOfDay(Hour, Minute);
        }

        #endregion

        #region Implementation of IEqualityComparer<in TimeOfDay>

        /// <inheritdoc />
        public virtual bool Equals(TimeOfDay x, TimeOfDay y)
        {
            return x.Equals(y);
        }

        /// <inheritdoc />
        public virtual int GetHashCode(TimeOfDay obj)
        {
            return obj.GetHashCode();
        }

        #endregion

        #region Implementation of IFormattable 

        /// <inheritdoc />
        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            return TimeSpan.ToString(format, formatProvider);
        }

        #endregion
        
        #region Overrides of object

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Hour:00}:{Minute:00}";
        }

        #endregion
    }
}