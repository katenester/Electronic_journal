using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBkp
{
    public partial class Form3 : Form
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

        public Form3()
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

        private void Form3_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=KR2023;Integrated Security=True");
            sqlConnection.Open();

            dataSet = new DataSet();

            sqlDataAdapter1 = new SqlDataAdapter($"SELECT *, 'Удалить' AS [Действие] FROM Успеваемость",
                    sqlConnection);
            LoadData(dGV1, "Успеваемость", 4, sqlDataAdapter1);
            sqlDataAdapter2 = new SqlDataAdapter($"SELECT *, 'Удалить' AS [Действие] FROM Задание",
                    sqlConnection);
            LoadData(dGV2, "Задание", 5, sqlDataAdapter2);
            sqlDataAdapter3 = new SqlDataAdapter($"SELECT *, 'Удалить' AS [Действие] FROM Дисциплина",
                    sqlConnection);
            LoadData(dGV3, "Дисциплина", 4, sqlDataAdapter3);
            sqlDataAdapter4 = new SqlDataAdapter($"SELECT *, 'Удалить' AS [Действие] FROM Студент",
                    sqlConnection);
            LoadData(dGV4, "Студент", 4, sqlDataAdapter4);
        }

        private void Reload1_Click(object sender, EventArgs e)
        {
            ReloadData(dGV1, "Успеваемость", 4, sqlDataAdapter1);
        }

        private void Reload2_Click(object sender, EventArgs e)
        {
            ReloadData(dGV2, "Задание", 5, sqlDataAdapter2);
        }

        private void Reload3_Click(object sender, EventArgs e)
        {
            ReloadData(dGV3, "Дисциплина", 4, sqlDataAdapter3);
        }

        private void Reload4_Click(object sender, EventArgs e)
        {
            ReloadData(dGV4, "Студент", 4, sqlDataAdapter4);
        }

        private void dGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            try
            {
                if (e.ColumnIndex == 4)
                {
                    string task = dGV1.Rows[e.RowIndex].Cells[4].Value.ToString();

                    if (task == "Удалить")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dGV1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Успеваемость"].Rows[rowIndex].Delete();
                            sqlDataAdapter1.Update(dataSet, "Успеваемость");
                        }
                    }
                    else if (task == "Вставить")
                    {
                        int rowIndex = dGV1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Успеваемость"].NewRow();

                        row["ID_задание"] = dGV1.Rows[rowIndex].Cells["ID_задание"].Value;
                        row["ID_дисц"] = dGV1.Rows[rowIndex].Cells["ID_дисц"].Value;
                        row["ID_студ"] = dGV1.Rows[rowIndex].Cells["ID_студ"].Value;
                        row["Оценка"] = dGV1.Rows[rowIndex].Cells["Оценка"].Value;

                        dataSet.Tables["Успеваемость"].Rows.Add(row);
                        dataSet.Tables["Успеваемость"].Rows.RemoveAt(dataSet.Tables["Успеваемость"].Rows.Count - 1);
                        dGV1.Rows.RemoveAt(dGV1.Rows.Count - 2);
                        dGV1.Rows[e.RowIndex].Cells[4].Value = "Удалить";

                        sqlDataAdapter1.Update(dataSet, "Успеваемость");

                        newRowAdding1 = false;
                    }
                    else if (task == "Обновить")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Успеваемость"].Rows[r]["ID_задание"] = dGV1.Rows[r].Cells["ID_задание"].Value;
                        dataSet.Tables["Успеваемость"].Rows[r]["ID_дисц"] = dGV1.Rows[r].Cells["ID_дисц"].Value;
                        dataSet.Tables["Успеваемость"].Rows[r]["ID_студ"] = dGV1.Rows[r].Cells["ID_студ"].Value;
                        dataSet.Tables["Успеваемость"].Rows[r]["Оценка"] = dGV1.Rows[r].Cells["Оценка"].Value;

                        sqlDataAdapter1.Update(dataSet, "Успеваемость");

                        dGV1.Rows[e.RowIndex].Cells[4].Value = "Удалить";
                    }

                    ReloadData(dGV1, "Успеваемость", 4, sqlDataAdapter1);
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
                    dGV1[4, lastRow] = lc;
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
                    dGV1[4, rowIndex] = lc;
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
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
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
                            dataSet.Tables["Задание"].Rows[rowIndex].Delete();
                            sqlDataAdapter2.Update(dataSet, "Задание");
                        }
                    }
                    else if (task == "Вставить")
                    {
                        int rowIndex = dGV2.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Задание"].NewRow();

                        row["ID_задание"] = dGV2.Rows[rowIndex].Cells["ID_задание"].Value;
                        row["ID_дисц"] = dGV2.Rows[rowIndex].Cells["ID_дисц"].Value;
                        row["Название"] = dGV2.Rows[rowIndex].Cells["Название"].Value;
                        row["Вес"] = dGV2.Rows[rowIndex].Cells["Вес"].Value;
                        row["Обязательно"] = dGV2.Rows[rowIndex].Cells["Обязательно"].Value;

                        dataSet.Tables["Задание"].Rows.Add(row);
                        dataSet.Tables["Задание"].Rows.RemoveAt(dataSet.Tables["Задание"].Rows.Count - 1);
                        dGV2.Rows.RemoveAt(dGV2.Rows.Count - 2);
                        dGV2.Rows[e.RowIndex].Cells[5].Value = "Удалить";

                        sqlDataAdapter2.Update(dataSet, "Задание");

                        newRowAdding2 = false;
                    }
                    else if (task == "Обновить")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Задание"].Rows[r]["ID_задание"] = dGV2.Rows[r].Cells["ID_задание"].Value;
                        dataSet.Tables["Задание"].Rows[r]["ID_дисц"] = dGV2.Rows[r].Cells["ID_дисц"].Value;
                        dataSet.Tables["Задание"].Rows[r]["Название"] = dGV2.Rows[r].Cells["Название"].Value;
                        dataSet.Tables["Задание"].Rows[r]["Вес"] = dGV2.Rows[r].Cells["Вес"].Value;
                        dataSet.Tables["Задание"].Rows[r]["Обязательно"] = dGV2.Rows[r].Cells["Обязательно"].Value;

                        sqlDataAdapter2.Update(dataSet, "Задание");

                        dGV2.Rows[e.RowIndex].Cells[5].Value = "Удалить";
                    }

                    ReloadData(dGV2, "Задание", 5, sqlDataAdapter2);
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
            if (dGV2.CurrentCell.ColumnIndex == 0 || dGV2.CurrentCell.ColumnIndex == 1
                || dGV2.CurrentCell.ColumnIndex == 3)
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
                if (e.ColumnIndex == 4)
                {
                    string task = dGV3.Rows[e.RowIndex].Cells[4].Value.ToString();

                    if (task == "Удалить")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dGV3.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Дисциплина"].Rows[rowIndex].Delete();
                            sqlDataAdapter3.Update(dataSet, "Дисциплина");
                        }
                    }
                    else if (task == "Вставить")
                    {
                        int rowIndex = dGV3.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Дисциплина"].NewRow();

                        row["ID_дисц"] = dGV3.Rows[rowIndex].Cells["ID_дисц"].Value;
                        row["Название"] = dGV3.Rows[rowIndex].Cells["Название"].Value;
                        row["Количество часов"] = dGV3.Rows[rowIndex].Cells["Количество часов"].Value;
                        row["ЗЕ"] = dGV3.Rows[rowIndex].Cells["ЗЕ"].Value;

                        dataSet.Tables["Дисциплина"].Rows.Add(row);
                        dataSet.Tables["Дисциплина"].Rows.RemoveAt(dataSet.Tables["Дисциплина"].Rows.Count - 1);
                        dGV3.Rows.RemoveAt(dGV3.Rows.Count - 2);
                        dGV3.Rows[e.RowIndex].Cells[4].Value = "Удалить";

                        sqlDataAdapter3.Update(dataSet, "Дисциплина");

                        newRowAdding3 = false;
                    }
                    else if (task == "Обновить")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Дисциплина"].Rows[r]["ID_дисц"] = dGV3.Rows[r].Cells["ID_дисц"].Value;
                        dataSet.Tables["Дисциплина"].Rows[r]["Название"] = dGV3.Rows[r].Cells["Название"].Value;
                        dataSet.Tables["Дисциплина"].Rows[r]["Количество часов"] = dGV3.Rows[r].Cells["Количество часов"].Value;
                        dataSet.Tables["Дисциплина"].Rows[r]["ЗЕ"] = dGV3.Rows[r].Cells["ЗЕ"].Value;

                        sqlDataAdapter3.Update(dataSet, "Дисциплина");

                        dGV3.Rows[e.RowIndex].Cells[4].Value = "Удалить";
                    }

                    ReloadData(dGV3, "Дисциплина", 4, sqlDataAdapter3);
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
                    dGV3[4, lastRow] = lc;
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
                    dGV3[4, rowIndex] = lc;
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
            if (dGV3.CurrentCell.ColumnIndex == 0 || dGV3.CurrentCell.ColumnIndex == 2
                || dGV3.CurrentCell.ColumnIndex == 3)
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
                            dataSet.Tables["Студент"].Rows[rowIndex].Delete();
                            sqlDataAdapter4.Update(dataSet, "Студент");
                        }
                    }
                    else if (task == "Вставить")
                    {
                        int rowIndex = dGV4.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Студент"].NewRow();

                        row["ID_студ"] = dGV4.Rows[rowIndex].Cells["ID_студ"].Value;
                        row["ФИО_студ"] = dGV4.Rows[rowIndex].Cells["ФИО_студ"].Value;
                        row["ID_группа"] = dGV4.Rows[rowIndex].Cells["ID_группа"].Value;
                        row["Пол"] = dGV4.Rows[rowIndex].Cells["Пол"].Value;

                        dataSet.Tables["Студент"].Rows.Add(row);
                        dataSet.Tables["Студент"].Rows.RemoveAt(dataSet.Tables["Студент"].Rows.Count - 1);
                        dGV4.Rows.RemoveAt(dGV4.Rows.Count - 2);
                        dGV4.Rows[e.RowIndex].Cells[4].Value = "Удалить";

                        sqlDataAdapter4.Update(dataSet, "Студент");

                        newRowAdding4 = false;
                    }
                    else if (task == "Обновить")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Студент"].Rows[r]["ID_студ"] = dGV4.Rows[r].Cells["ID_студ"].Value;
                        dataSet.Tables["Студент"].Rows[r]["ФИО_студ"] = dGV4.Rows[r].Cells["ФИО_студ"].Value;
                        dataSet.Tables["Студент"].Rows[r]["ID_группа"] = dGV4.Rows[r].Cells["ID_группа"].Value;
                        dataSet.Tables["Студент"].Rows[r]["Пол"] = dGV4.Rows[r].Cells["Пол"].Value;

                        sqlDataAdapter4.Update(dataSet, "Студент");

                        dGV4.Rows[e.RowIndex].Cells[4].Value = "Удалить";
                    }

                    ReloadData(dGV4, "Студент", 4, sqlDataAdapter4);
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
            if (dGV4.CurrentCell.ColumnIndex == 0 || dGV4.CurrentCell.ColumnIndex == 2)
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
