using System;

namespace TTA
{
    /// <summary>
    /// Encapsulates the data and functionality of a computer memory region.
    /// </summary>
    public abstract class Region
    {
        public Region(int Start, int End)
        {
            this.Start = Start;
            this.End = End;
        }

        /// <summary>
        /// Gets the location of the start of this region.
        /// </summary>
        public readonly int Start;

        /// <summary>
        /// Gets the location of the end of this region.
        /// </summary>
        public readonly int End;

        /// <summary>
        /// Determines whether this region contains the given location.
        /// </summary>
        public bool Contains(int Location)
        {
            return Location >= Start && Location < End;
        }

        /// <summary>
        /// Gets or sets the data at the given location, if possible.
        /// </summary>
        public abstract short this[int Index] { get; set; }

        /// <summary>
        /// Performs a read on this region, subject to the security constraints on the given instruction location.
        /// </summary>
        public virtual short SecureRead(int Location, int From)
        {
            return this[Location];
        }

        /// <summary>
        /// Performs a secure write on this region, subject to the security constraints on the given instruction location.
        /// </summary>
        public virtual void SecureWrite(int Location, short Data, int From)
        {
            this[Location] = Data;
        }

        /// <summary>
        /// Performs a read on this region, subject to the security constraints on the observer.
        /// </summary>
        public virtual short SecureRead(int Location)
        {
            return this[Location];
        }

        /// <summary>
        /// Performs a secure write on this region, subject to the security constraints on the observer.
        /// </summary>
        public virtual void SecureWrite(int Location, short Data)
        {
            this[Location] = Data;
        }
    }

    /// <summary>
    /// A functional region that contains an accumulator and a set of trigger ports for mathematical functions.
    /// </summary>
    public sealed class AccumulatorRegion : Region
    {
        public AccumulatorRegion(int Start)
                : base(Start, Start + Size)
        {
            
        }

        /// <summary>
        /// The current value of this accumulator.
        /// </summary>
        public int Value = 0;

        /// <summary>
        /// The size of an accumulator region.
        /// </summary>
        public static readonly int Size = 14;

        /// <summary>
        /// Contains the set of triggers for an accumulator.
        /// </summary>
        public enum Triggers
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Or,
            And,
            Xor,
            Xand,
            Equal,
            Less,
            LessEqual,
            Greater,
            GreaterEqual
        }
    }
}