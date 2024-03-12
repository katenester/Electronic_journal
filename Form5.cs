using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBkp
{
    public partial class Form5 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private SqlDataAdapter sqlDataAdapter1 = null;
        private SqlDataAdapter sqlDataAdapter2 = null;
        private SqlDataAdapter sqlDataAdapter3 = null;
        private SqlDataAdapter sqlDataAdapter4 = null;
        private DataSet dataSet = null;

        private bool newRowAdding1 = false;
        private bool newRowAdding2 = false;
        private bool newRowAdding3 = false;
        private bool newRowAdding4 = false;

        public Form5()
        {
            InitializeComponent();
        }

        private void cl1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadData(DataGridView dgv, string tablename, int j, SqlDataAdapter sqlDataAdapter)
        {
            try
            {
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlCommandBuilder.GetInsertCommand();
                sqlCommandBuilder.GetUpdateCommand();
                sqlCommandBuilder.GetDeleteCommand();

                sqlDataAdapter.Fill(dataSet, tablename);

                dgv.DataSource = dataSet.Tables[tablename];

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    DataGridViewLinkCell lc = new DataGridViewLinkCell();

                    dgv[j, i] = lc;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ReloadData(DataGridView dgv, string tablename, int j, SqlDataAdapter sqlDataAdapter)
        {
            try
            {
                dataSet.Tables[tablename].Clear();

                sqlDataAdapter.Fill(dataSet, tablename);

                dgv.DataSource = dataSet.Tables[tablename];

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    DataGridViewLinkCell lc = new DataGridViewLinkCell();

                    dgv[j, i] = lc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=KR2023;Integrated Security=True");
            sqlConnection.Open();

            dataSet = new DataSet();

            sqlDataAdapter1 = new SqlDataAdapter($"SELECT *, 'Удалить' AS [Действие] FROM Преподаватель",
                    sqlConnection);
            LoadData(dGV1, "Преподаватель", 5, sqlDataAdapter1);
            sqlDataAdapter2 = new SqlDataAdapter($"SELECT *, 'Удалить' AS [Действие] FROM Учебная_группа",
                    sqlConnection);
            LoadData(dGV2, "Учебная_группа", 5, sqlDataAdapter2);

            sqlDataAdapter3 = new SqlDataAdapter($"SELECT *, 'Удалить' AS [Действие] FROM Группа_дисциплина_преподаватель",
                    sqlConnection);
            LoadData(dGV3, "Группа_дисциплина_преподаватель", 3, sqlDataAdapter3);
            sqlDataAdapter4 = new SqlDataAdapter($"SELECT *, 'Удалить' AS [Действие] FROM Дисциплина",
                    sqlConnection);
            LoadData(dGV4, "Дисциплина", 4, sqlDataAdapter4);
        }

        private void Reload1_Click(object sender, EventArgs e)
        {
            ReloadData(dGV1, "Преподаватель", 5, sqlDataAdapter1);
        }

        private void Reload2_Click(object sender, EventArgs e)
        {
            ReloadData(dGV2, "Учебная_группа", 5, sqlDataAdapter2);
        }

        private void Reload3_Click(object sender, EventArgs e)
        {
            ReloadData(dGV3, "Группа_дисциплина_преподаватель", 3, sqlDataAdapter3);
        }

        private void Reload4_Click(object sender, EventArgs e)
        {
            ReloadData(dGV4, "Дисциплина", 4, sqlDataAdapter4);
        }

        private void dGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string task = dGV1.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (task == "Удалить")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dGV1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Преподаватель"].Rows[rowIndex].Delete();
                            sqlDataAdapter1.Update(dataSet, "Преподаватель");
                        }
                    }
                    else if (task == "Вставить")
                    {
                        int rowIndex = dGV1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Преподаватель"].NewRow();

                        row["ID_преп"] = dGV1.Rows[rowIndex].Cells["ID_преп"].Value;
                        row["ФИО_преп"] = dGV1.Rows[rowIndex].Cells["ФИО_преп"].Value;
                        row["Должность"] = dGV1.Rows[rowIndex].Cells["Должность"].Value;
                        row["Кафедра"] = dGV1.Rows[rowIndex].Cells["Кафедра"].Value;
                        row["Пол"] = dGV1.Rows[rowIndex].Cells["Пол"].Value;

                        dataSet.Tables["Преподаватель"].Rows.Add(row);
                        dataSet.Tables["Преподаватель"].Rows.RemoveAt(dataSet.Tables["Преподаватель"].Rows.Count - 1);
                        dGV1.Rows.RemoveAt(dGV1.Rows.Count - 2);
                        dGV1.Rows[e.RowIndex].Cells[5].Value = "Удалить";

                        sqlDataAdapter1.Update(dataSet, "Преподаватель");

                        newRowAdding1 = false;
                    }
                    else if (task == "Обновить")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Преподаватель"].Rows[r]["ID_преп"] = dGV1.Rows[r].Cells["ID_преп"].Value;
                        dataSet.Tables["Преподаватель"].Rows[r]["ФИО_преп"] = dGV1.Rows[r].Cells["ФИО_преп"].Value;
                        dataSet.Tables["Преподаватель"].Rows[r]["Должность"] = dGV1.Rows[r].Cells["Должность"].Value;
                        dataSet.Tables["Преподаватель"].Rows[r]["Кафедра"] = dGV1.Rows[r].Cells["Кафедра"].Value;
                        dataSet.Tables["Преподаватель"].Rows[r]["Пол"] = dGV1.Rows[r].Cells["Пол"].Value;

                        sqlDataAdapter1.Update(dataSet, "Преподаватель");

                        dGV1.Rows[e.RowIndex].Cells[5].Value = "Удалить";
                    }

                    ReloadData(dGV1, "Преподаватель", 5, sqlDataAdapter1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //
            try
            {
                if (!newRowAdding1)
                {
                    newRowAdding1 = true;

                    int lastRow = dGV1.Rows.Count - 2;

                    DataGridViewRow row = dGV1.Rows[lastRow];

                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    dGV1[5, lastRow] = lc;
                    row.Cells["Действие"].Value = "Вставить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (!newRowAdding1)
                {
                    int rowIndex = dGV1.SelectedCells[0].RowIndex;
                    DataGridViewRow row = dGV1.Rows[rowIndex];

                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    dGV1[5, rowIndex] = lc;
                    row.Cells["Действие"].Value = "Обновить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dGV1.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string task = dGV2.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (task == "Удалить")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dGV2.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Учебная_группа"].Rows[rowIndex].Delete();
                            sqlDataAdapter2.Update(dataSet, "Учебная_группа");
                        }
                    }
                    else if (task == "Вставить")
                    {
                        int rowIndex = dGV2.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Учебная_группа"].NewRow();

                        row["ID_группа"] = dGV2.Rows[rowIndex].Cells["ID_группа"].Value;
                        row["Номер"] = dGV2.Rows[rowIndex].Cells["Номер"].Value;
                        row["Количество студентов"] = dGV2.Rows[rowIndex].Cells["Количество студентов"].Value;
                        row["Кафедра"] = dGV2.Rows[rowIndex].Cells["Кафедра"].Value;
                        row["Курс"] = dGV2.Rows[rowIndex].Cells["Курс"].Value;

                        dataSet.Tables["Учебная_группа"].Rows.Add(row);
                        dataSet.Tables["Учебная_группа"].Rows.RemoveAt(dataSet.Tables["Учебная_группа"].Rows.Count - 1);
                        dGV2.Rows.RemoveAt(dGV2.Rows.Count - 2);
                        dGV2.Rows[e.RowIndex].Cells[5].Value = "Удалить";

                        sqlDataAdapter2.Update(dataSet, "Учебная_группа");

                        newRowAdding2 = false;
                    }
                    else if (task == "Обновить")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Учебная_группа"].Rows[r]["ID_группа"] = dGV2.Rows[r].Cells["ID_группа"].Value;
                        dataSet.Tables["Учебная_группа"].Rows[r]["Номер"] = dGV2.Rows[r].Cells["Номер"].Value;
                        dataSet.Tables["Учебная_группа"].Rows[r]["Количество студентов"] = dGV2.Rows[r].Cells["Количество студентов"].Value;
                        dataSet.Tables["Учебная_группа"].Rows[r]["Кафедра"] = dGV2.Rows[r].Cells["Кафедра"].Value;
                        dataSet.Tables["Учебная_группа"].Rows[r]["Курс"] = dGV2.Rows[r].Cells["Курс"].Value;

                        sqlDataAdapter2.Update(dataSet, "Учебная_группа");

                        dGV2.Rows[e.RowIndex].Cells[5].Value = "Удалить";
                    }

                    ReloadData(dGV2, "Учебная_группа", 5, sqlDataAdapter2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //
            try
            {
                if (!newRowAdding2)
                {
                    newRowAdding2 = true;

                    int lastRow = dGV2.Rows.Count - 2;

                    DataGridViewRow row = dGV2.Rows[lastRow];

                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    dGV2[5, lastRow] = lc;
                    row.Cells["Действие"].Value = "Вставить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (!newRowAdding2)
                {
                    int rowIndex = dGV2.SelectedCells[0].RowIndex;
                    DataGridViewRow row = dGV2.Rows[rowIndex];

                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    dGV2[5, rowIndex] = lc;
                    row.Cells["Действие"].Value = "Обновить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dGV2.CurrentCell.ColumnIndex == 0 || dGV2.CurrentCell.ColumnIndex == 2
                || dGV2.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void dGV4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (e.ColumnIndex == 4)
                {
                    string task = dGV4.Rows[e.RowIndex].Cells[4].Value.ToString();

                    if (task == "Удалить")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dGV4.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Дисциплина"].Rows[rowIndex].Delete();
                            sqlDataAdapter4.Update(dataSet, "Дисциплина");
                        }
                    }
                    else if (task == "Вставить")
                    {
                        int rowIndex = dGV4.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Дисциплина"].NewRow();

                        row["ID_дисц"] = dGV4.Rows[rowIndex].Cells["ID_дисц"].Value;
                        row["Название"] = dGV4.Rows[rowIndex].Cells["Название"].Value;
                        row["Количество часов"] = dGV4.Rows[rowIndex].Cells["Количество часов"].Value;
                        row["ЗЕ"] = dGV4.Rows[rowIndex].Cells["ЗЕ"].Value;

                        dataSet.Tables["Дисциплина"].Rows.Add(row);
                        dataSet.Tables["Дисциплина"].Rows.RemoveAt(dataSet.Tables["Дисциплина"].Rows.Count - 1);
                        dGV4.Rows.RemoveAt(dGV4.Rows.Count - 2);
                        dGV4.Rows[e.RowIndex].Cells[4].Value = "Удалить";

                        sqlDataAdapter4.Update(dataSet, "Дисциплина");

                        newRowAdding4 = false;
                    }
                    else if (task == "Обновить")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Дисциплина"].Rows[r]["ID_дисц"] = dGV4.Rows[r].Cells["ID_дисц"].Value;
                        dataSet.Tables["Дисциплина"].Rows[r]["Название"] = dGV4.Rows[r].Cells["Название"].Value;
                        dataSet.Tables["Дисциплина"].Rows[r]["Количество часов"] = dGV4.Rows[r].Cells["Количество часов"].Value;
                        dataSet.Tables["Дисциплина"].Rows[r]["ЗЕ"] = dGV4.Rows[r].Cells["ЗЕ"].Value;

                        sqlDataAdapter4.Update(dataSet, "Дисциплина");

                        dGV4.Rows[e.RowIndex].Cells[4].Value = "Удалить";
                    }

                    ReloadData(dGV4, "Дисциплина", 4, sqlDataAdapter4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV4_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //
            try
            {
                if (!newRowAdding4)
                {
                    newRowAdding4 = true;

                    int lastRow = dGV4.Rows.Count - 2;

                    DataGridViewRow row = dGV4.Rows[lastRow];

                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    dGV4[4, lastRow] = lc;
                    row.Cells["Действие"].Value = "Вставить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (!newRowAdding4)
                {
                    int rowIndex = dGV4.SelectedCells[0].RowIndex;
                    DataGridViewRow row = dGV4.Rows[rowIndex];

                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    dGV4[4, rowIndex] = lc;
                    row.Cells["Действие"].Value = "Обновить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV4_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dGV4.CurrentCell.ColumnIndex == 0 || dGV4.CurrentCell.ColumnIndex == 2
                || dGV4.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void dGV3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (e.ColumnIndex == 3)
                {
                    string task = dGV3.Rows[e.RowIndex].Cells[3].Value.ToString();

                    if (task == "Удалить")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dGV3.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Группа_дисциплина_преподаватель"].Rows[rowIndex].Delete();
                            sqlDataAdapter3.Update(dataSet, "Группа_дисциплина_преподаватель");
                        }
                    }
                    else if (task == "Вставить")
                    {
                        int rowIndex = dGV3.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Группа_дисциплина_преподаватель"].NewRow();

                        row["ID_группа"] = dGV3.Rows[rowIndex].Cells["ID_группа"].Value;
                        row["ID_дисц"] = dGV3.Rows[rowIndex].Cells["ID_дисц"].Value;
                        row["ID_преп"] = dGV3.Rows[rowIndex].Cells["ID_преп"].Value;

                        dataSet.Tables["Группа_дисциплина_преподаватель"].Rows.Add(row);
                        dataSet.Tables["Группа_дисциплина_преподаватель"].Rows.RemoveAt(dataSet.Tables["Группа_дисциплина_преподаватель"].Rows.Count - 1);
                        dGV3.Rows.RemoveAt(dGV3.Rows.Count - 2);
                        dGV3.Rows[e.RowIndex].Cells[3].Value = "Удалить";

                        sqlDataAdapter3.Update(dataSet, "Группа_дисциплина_преподаватель");

                        newRowAdding3 = false;
                    }
                    else if (task == "Обновить")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Группа_дисциплина_преподаватель"].Rows[r]["ID_группа"] = dGV3.Rows[r].Cells["ID_группа"].Value;
                        dataSet.Tables["Группа_дисциплина_преподаватель"].Rows[r]["ID_дисц"] = dGV3.Rows[r].Cells["ID_дисц"].Value;
                        dataSet.Tables["Группа_дисциплина_преподаватель"].Rows[r]["ID_преп"] = dGV3.Rows[r].Cells["ID_преп"].Value;

                        sqlDataAdapter3.Update(dataSet, "Группа_дисциплина_преподаватель");

                        dGV3.Rows[e.RowIndex].Cells[3].Value = "Удалить";
                    }

                    ReloadData(dGV3, "Группа_дисциплина_преподаватель", 3, sqlDataAdapter3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV3_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //
            try
            {
                if (!newRowAdding3)
                {
                    newRowAdding3 = true;

                    int lastRow = dGV3.Rows.Count - 2;

                    DataGridViewRow row = dGV3.Rows[lastRow];

                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    dGV3[3, lastRow] = lc;
                    row.Cells["Действие"].Value = "Вставить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (!newRowAdding3)
                {
                    int rowIndex = dGV3.SelectedCells[0].RowIndex;
                    DataGridViewRow row = dGV3.Rows[rowIndex];

                    DataGridViewLinkCell lc = new DataGridViewLinkCell();
                    dGV3[3, rowIndex] = lc;
                    row.Cells["Действие"].Value = "Обновить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dGV3_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dGV3.CurrentCell.ColumnIndex == 0 || dGV3.CurrentCell.ColumnIndex == 1
                || dGV3.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }
    }
}
