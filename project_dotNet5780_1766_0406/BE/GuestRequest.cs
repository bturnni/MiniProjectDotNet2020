﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest
    {
        private bool _guestRequestKey_setAlready = false;
        private double _guestRequestKey;
        public double GuestRequestKey
        {
            get => _guestRequestKey;
            set
            {
                if (!_guestRequestKey_setAlready)
                {
                    _guestRequestKey = value;
                    _guestRequestKey_setAlready = true;
                }
                else
                    throw new AccessViolationException("BE.GuestRequest._guestRequestKey property can only once change!");
            }
        }

        private string _privateName;
        public string PrivateName
        {
            set => _privateName = value;
            get => _privateName;
        }

        private string _familyName;
        public string FamilyName
        {
            set => _familyName = value;
            get => _familyName;
        }

        private string _email;
        public string Email
        {
            set => _email = value;
            get => _email;
        }

        private Enums.Status _stat;
        public Enums.Status Stat
        {
            set => _stat = value;
            get => _stat;
        }

        private DateTime _registrationDate;
        public DateTime RegistrationDate
        {
            set =>_registrationDate = value;
            get => _registrationDate;
        }

        private DateTime _entryDate;
        public DateTime EntryDate
        {
            set=>_entryDate = value;
            get => _entryDate;
        }

        private DateTime _releaseDate;
        public DateTime ReleaseDate
        {
            set => _releaseDate = value;
            get => _releaseDate;
        }

        private Enums.Area _area;
        public Enums.Area Area
        {
            set => _area = value;
            get => _area;
        }

        private Enums.UnitType _type { get; set; }
        public Enums.UnitType type
        {
            set => _type = value;
            get => _type;
        }

        private int _adults { get; set; }
        public int Adults
        {
            set => _adults = value;
            get => _adults;
        }

        private int _children { get; set; }
        public int Children
        {
            set => _children = value;
            get => _children;
        }

        private bool _pool { get; set; }
        public bool Pool
        {
            set => _pool = value;
            get => _pool;
        }

        private bool _jecuzzi { get; set; }
        public bool Jecuzzi
        {
            set => _jecuzzi = value;
            get => _jecuzzi;
        }

        private bool _garden;
        public bool Garden
        {
            set => _garden = value;
            get => _garden;
        }

        private bool _childrenAttractions;
        public bool ChildrenAttractions
        {
            set => _childrenAttractions = value;
            get => _childrenAttractions;
        }


        /// <summary>
        /// for now the c'tor is public, in order to make 3 instances that needed in DS.DataSource in the next part of the project we will make this class singleton
        /// </summary>
        public GuestRequest(string privateName, string familyName, string email, Enums.Status stat,
                            DateTime registrationDate, DateTime entryDate, DateTime releaseDate,
                            Enums.Area area, Enums.UnitType type_, int adults, int children,
                            bool pool, bool jecuzzi, bool garden, bool childrenAttractions)
        {
            GuestRequestKey = ++Configuration.GuestRequestKey;
            PrivateName = privateName;
            FamilyName = familyName;
            Email = email;
            Stat = stat;
            RegistrationDate = registrationDate;
            EntryDate = entryDate;
            ReleaseDate = releaseDate;
            Area = area;
            type = type_;
            Adults = adults;
            Children = children;
            Pool = pool;
            Jecuzzi = jecuzzi;
            Garden = garden;
            ChildrenAttractions = childrenAttractions;
        }

        public override string ToString()
        {

            return "Guest Request Key:\t" + _guestRequestKey +
                "\nPrivate Name:\t" + _privateName +
                "\nFamily Name:\t" + _familyName +
                "\nEmail:\t\t" + _email +
                "\nRegistration Date:\t" + _registrationDate.toString() +
                "\nEnty Date:\t\t" + _entryDate.toString() +
                "\nRelease Date:\t\t" + _releaseDate.toString() +
                "\nRequest Status:\t" + _stat +
                "\nRequest Area:\t" + _area +
                "\nType:\t\t" + _type +
                "\nAdults:\t\t" + _adults +
                "\nChildren:\t" + _children +
                "\nPool:\t\t\t" + _pool +
                "\nJecuzzi:\t\t" + _jecuzzi +
                "\nGarden:\t\t\t" + _garden +
                "\nChildren Attractions:\t" + _childrenAttractions;
        }

    }
}