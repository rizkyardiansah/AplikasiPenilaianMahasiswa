using System;
using System.Collections.Generic;
using System.Text;

namespace AplikasiPenilaianMahasiswa
{
    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }

        public Course(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public void describe()
        {
            Console.WriteLine($"ID: {Id}; Nama: {Name}");
        }

    }
}
