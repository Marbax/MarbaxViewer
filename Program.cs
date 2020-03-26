﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MarbaxViewer
{
    /// <summary>
    ///  Создать приложение «Галерея изображений».
    ///   Основная задача приложения:
    ///   - предоставить пользователю функциональность для отображения графических файлов различных форматов.
    ///   Интерфейс приложения должен предоставлять такие возможности:
    ///   - отображение файловой структуры; 
    ///   - если пользователь заходит в каталог с графическими изображениями, они должны отображаться в виде превью(в качестве примера можно взять механизм работы проводника); 
    ///   - если пользователь кликает по файлу, он отображается на весь экран.При этом необходимо предусмотреть навигацию вперед-назад по текущей папке с изображениями; 
    ///   - копирование, удаление, вставка, перенос графических файлов; 
    ///   - приложение должно поддерживать механизм Drag-and-Drop; 
    ///   - поиск графических файлов(имя файла, расширение, размер, дата создания, теги и т.д.); 
    ///   - история поиска сохраняется, и у пользователя есть возможность ее просмотреть; 
    ///   - конвертация файла в другой графический формат; 
    ///   - присвоение тегов папке с графическими файлам, конкретному файлу; 
    ///   - сохранение настроек приложения.Выбор настроек остается за вами.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Application.Run(new frmMain());
        }
        /*
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(@"MarbaxViewer.MaterialSkin.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
        */
    }
}
