using System;
using System.Collections.Generic;
using System.Text;

namespace AplikasiPenilaianMahasiswa
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private List<Course> enrolledCourse = new List<Course>();
        public Student(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public void describe()
        {
            Console.WriteLine($"ID: {Id}; Nama: {Name}");
        }

        public bool addCourse(Course c)
        {
            if (enrolledCourse.Contains(c))
            {
                Console.WriteLine("============================================================");
                Console.WriteLine($"Mahasiswa {Name} ({Id}) telah menggambil matakuliah {c.Name} ({c.Id})");
                Console.WriteLine("============================================================");
                return false;
            } else
            {
                enrolledCourse.Add(c);
                return true;
            }
        }

        public void enrollDetails()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine($"Mahasiswa {Name} ({Id}) mendaftar pada matakuliah berikut: ");
            foreach (Course c in enrolledCourse)
            {
                c.describe();
            }
        }
    }
}
