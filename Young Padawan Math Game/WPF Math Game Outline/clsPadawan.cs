using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Math_Game_Outline
{
    public class clsPadawan
    {
        /// <summary>
        /// jedi name
        /// </summary>
        public string sName {  get; set; } 

        /// <summary>
        /// jedi age
        /// </summary>
        public int iAge {  get; set; }

        /// <summary>
        /// bool to see if name is valid
        /// </summary>
        public bool vaildName;

        /// <summary>
        /// bool to see if age is valid
        /// </summary>
        public bool validAge;

        /// <summary>
        /// constructor for padawan class
        /// </summary>
        public clsPadawan() {
            sName = "";
            iAge = 0;
            vaildName = false;
            validAge = false;
        }

        /// <summary>
        /// check if user entered a valid name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Boolean isValidName(String name)
        {
            try
            {
                if (name == null)
                {
                    return false;
                }
                if (name.Length == 0)
                {
                    return false;
                }
                sName = name;
                return true;
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// check if user entered a valid age
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Boolean isValidAge(int age)
        {
            try
            {
                if (age >= 3 && age <= 10)
                {
                    iAge = age;
                    return true;
                }
                return false;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
    }


}
