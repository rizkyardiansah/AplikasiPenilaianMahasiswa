using System;
using System.Collections.Generic;

namespace AplikasiPenilaianMahasiswa
{
    class Program
    {
        private static Dictionary<Student, Course> enrollment = new Dictionary<Student, Course>();
        private static List<Student> students = new List<Student>();
        private static List<Course> courses = new List<Course>();
        private static int studentIdCounter = 1;
        private static int courseIdCounter = 1;

        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("Selamat Datang di Aplikasi Penilaian Mahasiswa");
                Console.WriteLine("==================================================");
                Console.WriteLine("Pilih salah satu menu berikut:");
                Console.WriteLine("1. Masukan Matakuliah");
                Console.WriteLine("2. Tambahkan Data Mahasiswa");
                Console.WriteLine("3. Daftarkan Mahasiswa dengan Matakuliah");
                Console.WriteLine("4. Tampilkan Data Mahasiswa");
                Console.WriteLine("5. Hapus Data Mahasiswa");
                Console.WriteLine("6. Akhiri Program");
                Console.Write("\nMasukan pilihan: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        addCourse();
                        break;

                    case "2":
                        Console.Clear();
                        addStudent();
                        break;

                    case "3":
                        Console.Clear();
                        enrollStudentToCourse();
                        break;

                    case "4":
                        Console.Clear();
                        showStudentData();
                        break;

                    case "5":
                        Console.Clear();
                        deleteStudentData();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("=================================================");
                        Console.WriteLine("Terima kasih telah menggunakan program ini");
                        Console.WriteLine("=================================================");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("=================================================");
                        Console.WriteLine("Masukkan tidak sesuai");
                        Console.WriteLine("=================================================");
                        break;
                }
            } while (input != "6");
        }

        public static void addCourse()
        {
           
            Console.Write("Masukan nama matakuliah: ");
            string courseName = Console.ReadLine();
            Course newCourse = new Course(courseIdCounter, courseName);
            courseIdCounter++;
            courses.Add(newCourse);

            Console.WriteLine("===============================================");
            Console.WriteLine($"Matakuliah {newCourse.Name} berhasil ditambahkan dengan ID {newCourse.Id}");
            Console.WriteLine("===============================================");
        }

        public static void addStudent()
        {
            Console.Write("Masukan nama mahasiswa: ");
            string studentName = Console.ReadLine();
            Student newStudent = new Student(studentIdCounter, studentName);
            studentIdCounter++;
            students.Add(newStudent);

            Console.WriteLine("===============================================");
            Console.WriteLine($"Mahasiswa {newStudent.Name} berhasil ditambahkan dengan ID {newStudent.Id}");
            Console.WriteLine("===============================================");
        }

        public static void enrollStudentToCourse()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Daftar Mahasiswa: ");
            foreach (Student s in students)
            {
                s.describe();
            }
            Console.WriteLine("===================================");
            Console.Write("Masukan ID Mahasiswa yang ingin mendaftar Matakuliah: ");
            int studentId = int.Parse(Console.ReadLine());
            Student studentFound = findStudent(studentId);
            if (studentFound == null)
            {
                Console.WriteLine("==========================");
                Console.WriteLine($"Mahasiswa dengan ID {studentId} tidak ditemukan");
                Console.WriteLine("==========================");
                return;
            }

            Console.WriteLine("===================================");
            Console.WriteLine("Daftar Matakuliah: ");
            foreach (Course c in courses)
            {
                c.describe();
            }
            Console.WriteLine("===================================");
            Console.Write("Masukan ID Matakuliah yang diikuti: ");
            int courseId = int.Parse(Console.ReadLine());
            Course courseFound = findCourse(courseId);
            if (courseFound == null)
            {
                Console.WriteLine("==========================");
                Console.WriteLine($"Matakuliah dengan ID {courseId} tidak ditemukan");
                Console.WriteLine("==========================");
                return;
            }

            bool isSuccess = studentFound.addCourse(courseFound);
            if (isSuccess)
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Mahasiswa {studentFound.Name} berhasil didaftarkan pada matakuliah {courseFound.Name}");
                Console.WriteLine("===================================");
            } else
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Mahasiswa {studentFound.Name} GAGAL didaftarkan pada matakuliah {courseFound.Name}");
                Console.WriteLine("===================================");
            }

        }

        public static void showStudentData()
        {
            foreach (Student s in students)
            {
                s.enrollDetails();
            }
        }

        public static void deleteStudentData()
        {

            Console.WriteLine("===================================");
            Console.WriteLine("Daftar Mahasiswa: ");
            foreach (Student s in students)
            {
                s.describe();
            }
            Console.WriteLine("===================================");
            Console.Write("Masukan ID Mahasiswa yang ingin dihapus: ");
            int studentId = int.Parse(Console.ReadLine());
            Student studentFound = findStudent(studentId);
            if (studentFound == null)
            {
                Console.WriteLine("==========================");
                Console.WriteLine($"Mahasiswa dengan ID {studentId} tidak ditemukan");
                Console.WriteLine("==========================");
                return;
            }

            bool isDeleteSuccess = students.Remove(studentFound);
            if (isDeleteSuccess)
            {
                Console.WriteLine("===============================================");
                Console.WriteLine($"Mahasiswa {studentFound.Name} ({studentFound.Id}) berhasil dihapus");
                Console.WriteLine("===============================================");
            } else
            {
                Console.WriteLine("===============================================");
                Console.WriteLine($"Mahasiswa {studentFound.Name} ({studentFound.Id}) GAGAL dihapus");
                Console.WriteLine("===============================================");
            }
        }

        public static Course findCourse(int courseId)
        {
            foreach (Course c in courses)
            {
                if (c.Id == courseId)
                {
                    return c;
                }
            }
            return null;
        }

        public static Student findStudent(int studentId)
        {
            foreach (Student s in students)
            {
                if (s.Id == studentId)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
