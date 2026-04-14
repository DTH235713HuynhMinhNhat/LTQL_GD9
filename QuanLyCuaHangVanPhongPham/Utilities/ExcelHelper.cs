using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace QuanLyVanPhongPham.Utilities
{
    public static class ExcelHelper
    {
        /// <summary>
        /// Xuất dữ liệu từ DataGridView ra file Excel (.xlsx)
        /// </summary>
        /// <param name="dgv">DataGridView chứa dữ liệu</param>
        /// <param name="sheetName">Tên sheet trong Excel</param>
        public static void ExportToExcel(DataGridView dgv, string sheetName = "Sheet1")
        {
            bool hasData = dgv.Rows.Count > 0;
            
            // Nếu Rows.Count = 0, kiểm tra xem có DataSource không (phòng trường hợp grid chưa kịp render)
            if (!hasData && dgv.DataSource != null)
            {
                if (dgv.DataSource is System.Collections.IList list) hasData = list.Count > 0;
                else if (dgv.DataSource is DataTable dt) hasData = dt.Rows.Count > 0;
            }

            if (!hasData)
            {
                MessageBox.Show("Không tìm thấy dữ liệu trong bảng để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"{sheetName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add(sheetName);

                            // 1. Tạo tiêu đề cột (chỉ lấy các cột đang hiển thị và không phải là Image)
                            int colIndex = 1;
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                if (dgv.Columns[i].Visible && !(dgv.Columns[i] is DataGridViewImageColumn))
                                {
                                    worksheet.Cell(1, colIndex).Value = dgv.Columns[i].HeaderText;
                                    worksheet.Cell(1, colIndex).Style.Font.Bold = true;
                                    worksheet.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.LightGray;
                                    colIndex++;
                                }
                            }

                            // 2. Chuyển dữ liệu từ DGV sang Excel
                            for (int r = 0; r < dgv.Rows.Count; r++)
                            {
                                colIndex = 1;
                                for (int c = 0; c < dgv.Columns.Count; c++)
                                {
                                    if (dgv.Columns[c].Visible && !(dgv.Columns[c] is DataGridViewImageColumn))
                                    {
                                        var value = dgv.Rows[r].Cells[c].Value;
                                        worksheet.Cell(r + 2, colIndex).Value = value?.ToString() ?? "";
                                        colIndex++;
                                    }
                                }
                            }

                            // 3. Tự động căn chỉnh độ rộng cột
                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /// <summary>
        /// Xuất dữ liệu từ DataTable ra file Excel (.xlsx)
        /// </summary>
        public static void ExportDataTableToExcel(DataTable dt, string sheetName = "Sheet1")
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu báo cáo trống, không có gì để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"{sheetName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Data");

                            // Chèn DataTable trực tiếp vào worksheet
                            worksheet.Cell(1, 1).InsertTable(dt);

                            // Tự động căn chỉnh độ rộng cột
                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
