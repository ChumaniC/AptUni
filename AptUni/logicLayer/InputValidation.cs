using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AptUni.logicLayer
{
    public class InputValidation
    {
        public Page Page { get; set; }
        // Method validates provided email address

        public void Email_Validation(string insertQuery, string selectQuery_One, string sqlParameter_One, string errorFunctionExists, string errorFunctionLength, int characterLimit, ITextControl input_One, SqlCommand theInsertCommand, SqlConnection sqlConnection)
        {
            try
            {
                // Create SQL command

                SqlCommand command_ID_Number = new SqlCommand(selectQuery_One, sqlConnection);
                command_ID_Number.Parameters.AddWithValue(sqlParameter_One, input_One.Text);

                // Validate whether provided input does not exceed character limit

                if (input_One.Text.Length <= characterLimit)
                {
                    // Validate whether provided input does not exist already in database

                    using (var reader_ID = command_ID_Number.ExecuteReader())
                    {
                        if (reader_ID.HasRows)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_Err", errorFunctionExists, true);
                        }
                        else
                        {
                            if (reader_ID.HasRows == false)
                            {
                                theInsertCommand.Parameters.AddWithValue(sqlParameter_One, input_One.Text);
                            }
                        }
                    }
                }
                else
                {
                    if (input_One.Text.Length > characterLimit)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_Err", errorFunctionLength, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Page.Response.Write(ex.ToString());
            }
        }

        // Method validates all string input controls

        public void validation_check_stringInput(string insertQuery, string sqlParameter_One, string errorFunctionLength, int characterLimit, ITextControl input_One, SqlCommand theInsertCommand, SqlConnection sqlConnection)
        {
            try
            {
                // Validate whether provided input does not exceed character limit

                if (input_One.Text.Length <= characterLimit)
                {
                    theInsertCommand.Parameters.AddWithValue(sqlParameter_One, input_One.Text);
                }
                else
                {
                    if (input_One.Text.Length > characterLimit)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_Err", errorFunctionLength, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Page.Response.Write(ex.ToString());
            }
        }

        public bool isNumeric(ITextControl numericCtrl)
        {
            bool numericValue = true;
            try
            {
                int userInput;

                if (int.TryParse(numericCtrl.Text, out userInput))
                {
                    numericValue = true;
                }
                else
                {
                    numericValue = false;
                }
            }
            catch (Exception)
            {
            }
            return numericValue;
        }

        // Method validates all integer input controls

        public void validation_check_intInput(string insertQuery, string sqlParameter_One, string errorFunctionLength, string errorFunctionNumeric, int characterLimit, ITextControl input_One, SqlCommand theInsertCommand, SqlConnection sqlConnection)
        {
            try
            {
                // Validate whether provided input does not exceed character limit

                if (input_One.Text.Length == characterLimit)
                {
                    // Validate whether user input is an integer

                    if (isNumeric(input_One) == true)
                    {
                        theInsertCommand.Parameters.AddWithValue(sqlParameter_One, input_One.Text);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_Err", errorFunctionNumeric, true);
                    }
                }
                else
                {
                    if (input_One.Text.Length > characterLimit)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_Err", errorFunctionLength, true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_Err", errorFunctionLength, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Page.Response.Write(ex.ToString());
            }
        }   
    }
}