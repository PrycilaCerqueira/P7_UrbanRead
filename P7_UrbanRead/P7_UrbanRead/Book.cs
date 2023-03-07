﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class Book
    {
        private string _Cover; //Source of the cover image
        private string _Title;
        private string _Subtitle;
        private string _Description;
        private int  _TotalPages;
        private List<ISBN> _ISBNS = new List<ISBN>();
        private List<Author> _Authors = new List<Author>();
        private string _PublisherName; //verify if the type is correct
        private DateTime _PublishedDate; //verify if the type is correct
        private LangType _Language; 
        private string _Genre; 
        private BookFormat _BookFormat;
        private ReadStatus _ReadingStatus;
        private int _PageAt;

        public string Cover
        {
            get { return _Cover; }
            set { _Cover = value; }
        }
        public string Title
        {
            get { return _Title; }  
            set { _Title = value; }
        }
        public string Subtitle
        {
            get { return _Subtitle; }
            set { _Subtitle = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        } 
        public int TotalPages
        {
            get { return _TotalPages; }
            set { _TotalPages = value; }
        }
        public DateTime PublishedDate
        {
            get { return _PublishedDate; }
            set { _PublishedDate = value; }
        }
        public List<ISBN> ISBNS
        {
            get { return _ISBNS; }
            set { _ISBNS = value; }
        }
        public List<Author> Authors
        {
            get { return _Authors; }
            set { _Authors = value; }
        }
        public string PublisherName
        {
            get { return _PublisherName; }
            set { _PublisherName = value; }
        }
        public LangType Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        public string Genre
        {
            get { return _Genre; }
            set { _Genre = value; }
        }

        public BookFormat Type
        {
            get { return _BookFormat; }
            set { _BookFormat = value; }
        }
        public ReadStatus ReadingStatus
        {
            get { return _ReadingStatus; }
            set { _ReadingStatus = value; }
        }
        public int PageAt
        {
            get { return _PageAt; }
            set { _PageAt = value; }
        }
    }
}
