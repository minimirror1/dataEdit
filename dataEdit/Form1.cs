using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataEdit
{
    public partial class Hikim : Form
    {
        private string motionDBpath = null;
        public Hikim()
        {
            this.Text = "HiKim";
            InitializeComponent();
            InitializeDataGridView();
            OpenFolderPath();

            motionGridView.AllowUserToAddRows = false; // 빈 행을 허용하지 않음
            motionGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #region Unit불러오기
        /* 프로그램 부팅시 폴더 지정 */
        private void OpenFolderPath()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;
                    motionDBpath = selectedFolderPath;
                    //MessageBox.Show(motionDBpath);

                    /* 예외처리 csv 파일 없음 */
                    bool hasCsvFiles = Directory.GetFiles(selectedFolderPath, "*.CSV").Any();
                    if (hasCsvFiles)
                    {                        
                        //MessageBox.Show("폴더 내에 CSV 파일이 존재합니다.");
                        statusLabel.Text = "폴더 내에 CSV 파일이 존재합니다.";
                    }
                    else
                    {
                        MessageBox.Show("폴더 내에 CSV 파일이 없습니다.");
                        statusLabel.Text = "폴더 선택이 취소되었거나 유효하지 않습니다.";
                        return;
                    }

                    readUnitMotion(selectedFolderPath);
                }
                else
                {
                    Console.WriteLine("폴더 선택이 취소되었거나 유효하지 않습니다.");
                    statusLabel.Text = "폴더 선택이 취소되었거나 유효하지 않습니다.";
                }
            }
        }
        private void readUnitMotion(string path)
        {
            // 폴더 내의 파일 목록 가져오기
            string[] files = Directory.GetFiles(path);

            // 파일 목록을 출력 또는 다른 작업 수행
            foreach (string file in files)
            {
                Console.WriteLine(file);
                string fileName = Path.GetFileName(file);
                fileDataGridView.Rows.Add(ReadMotionTime(file), fileName);
                statusLabel.Text = fileName + "를 찾았습니다.";
            }
        }
        #endregion

        private void InitializeDataGridView()
        {
            // DataGridView에 열 추가
            motionGridView.Columns.Add("Column1", "시작 시간");
            motionGridView.Columns["Column1"].Width = 100;

            motionGridView.Columns.Add("Column2", "끝 시간");
            motionGridView.Columns["Column2"].Width = 100;

            motionGridView.Columns.Add("Column3", "모션 이름");
            motionGridView.Columns["Column3"].Width = 200;

            motionGridView.Columns.Add("Column4", "모션 시간");
            motionGridView.Columns["Column4"].Width = 100;



            fileDataGridView.Columns.Add("Column1", "모션 시간");
            fileDataGridView.Columns["Column1"].Width = 100;

            fileDataGridView.Columns.Add("Column2", "모션 이름");
            fileDataGridView.Columns["Column2"].Width = 200;
        }


        /* 목록 마지막에 추가 */
        private void LastAdd_Click(object sender, EventArgs e)
        {
            // 버튼 클릭 시 선택된 행의 데이터 가져오기
            if (fileDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = fileDataGridView.SelectedRows[0];                

                // 각 열의 데이터 가져오기
                string motion_Time = selectedRow.Cells["Column1"].Value.ToString();//시간
                string motion_Name = selectedRow.Cells["Column2"].Value.ToString();//모션이름                

                // 가져온 데이터를 출력 또는 다른 작업 수행                

                int rowCount = motionGridView.Rows.Count;
                if (rowCount == 0)
                {
                    motionGridView.Rows.Add(
                        0,              //모션 시작시간
                        motion_Time,    //모션 끝시간
                        motion_Name,    //모션 이름
                        motion_Time     //모션 시간
                        );                    
                }
                else
                {
                    DataGridViewRow aboveLastRow = motionGridView.Rows[rowCount-1];//현재 마지막 행 값

                    // "Column2" 열의 셀을 찾기
                    DataGridViewCell cell = aboveLastRow.Cells["Column2"];

                    if (cell != null && cell.Value != null)
                    {
                        string above_Time = cell.Value.ToString();
                        // 나머지 코드
                        motionGridView.Rows.Add(
                        above_Time,     //이전 모션의 끝시간 -> 현재 추가된 모션의 시작시간
                        AddAndConvertToString(above_Time, motion_Time), //현재 모션 종료 시간         
                        motion_Name,     //현재 모션의 이름.
                        motion_Time    //현재 모션의 시간            
                        );
                       
                    }
                    else
                    {
                        // "Column2" 열에 값이 없는 경우 처리
                        statusLabel.Text = "셀에 값이 없습니다.";
                    }       
                }



                statusLabel.Text = motion_Name + "를 목록에 추가합니다.";

            }
            else
            {
                MessageBox.Show("선택된 행이 없습니다.");
            }
        }

        private void motionGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // 선택된 행이 있을 경우
                //MotionGridView.Rows.RemoveAt(1);
            }
        }

        /* 모션 생성, 검사 저장 */
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveMotion();
        }

        /* 단위 모션 리스트 선택 */
        private void fileDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // 클릭된 셀의 행과 열 인덱스 가져오기
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;

                // 클릭된 셀의 내용 가져오기
                object cellValue = fileDataGridView.Rows[rowIndex].Cells[1].Value;

                //MessageBox.Show($"클릭된 셀: 행 {rowIndex}, 열 {columnIndex}, 내용: {cellValue}");
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    // 셀의 값이 비어 있지 않은 경우에 수행할 작업
                    statusLabel.Text = cellValue + "를 선택했습니다.";
                }
                else
                {
                    // 셀의 값이 비어 있는 경우에 수행할 작업
                    statusLabel.Text = "빈칸을 선택했습니다.";
                }
            }
        }

        /* csv 파일 읽기 */
        private void ReadCsvFile(string filePath)
        {
            try
            {
                // 파일이 존재하는지 확인
                if (File.Exists(filePath))
                {
                    // CSV 파일의 모든 행 읽기
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        // 각 행을 ','로 나누어 열로 분리
                        string[] columns = line.Split(',');

                        // 분리된 열 출력 또는 다른 작업 수행
                        foreach (string column in columns)
                        {
                            Console.Write(column + " ");
                        }

                        Console.WriteLine(); // 다음 행으로 이동
                    }
                }
                else
                {
                    Console.WriteLine("파일이 존재하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }
        private String ReadMotionTime(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                string lastLine = null;

                while ((line = reader.ReadLine()) != null)
                {
                    lastLine = line;
                }

                if (lastLine != null)
                {
                    string[] values = lastLine.Split(',');

                    // 각 열의 값을 출력하거나 다른 작업 수행
                    foreach (string value in values)
                    {
                        Console.Write(value + " ");
                    }
                    return values[0];
                }
                else
                {
                    MessageBox.Show("마지막 시간값이 비어있습니다.");
                    return null;
                }
            }
        }
        private void SaveMotion()
        {
            // 저장할 파일의 내용 (예: 텍스트 파일 내용)
           

            // SaveFileDialog 생성
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // 파일 필터 지정 (예: 텍스트 파일)
            saveFileDialog1.Filter = "CSV 파일 (*.CSV)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = "MTC_ALL.CSV";

            // 다이얼로그를 띄우고 사용자가 선택한 파일 경로 가져오기
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 사용자가 선택한 파일 경로
                string filePath = saveFileDialog1.FileName;

                // 파일 저장
                
                string[] sumData = new string[1]; 

                foreach (DataGridViewRow row in motionGridView.Rows)
                {
                    if (!row.IsNewRow) // 새로운 행이 아닌 경우에만 처리
                    {

                        // "Column2" 열의 셀을 찾기
                        DataGridViewCell startTime = row.Cells["Column1"];
                        DataGridViewCell endTime = row.Cells["Column2"];
                        DataGridViewCell fileName = row.Cells["Column3"];                        

                        if (fileName != null && fileName.Value != null)
                        {
                            if(fileName.Value.ToString() != "휴식")
                            {
                                if (int.TryParse(startTime.Value.ToString(), out int startTimeValue))
                                {
                                    SumMotionData(fileName.Value.ToString(), startTimeValue, ref sumData);
                                }
                            }                                                          
                        }
                    }
                }


                /* 시간 연속성 검사 */
                /* 축 별 이음매 검사 */


                if (sumData != null)
                {
                    string resultString = string.Join("\r\n", sumData);
                    System.IO.File.WriteAllText(filePath, resultString);

                    statusLabel.Text = "파일이 저장되었습니다. 경로: " + filePath;
                    Console.WriteLine($"파일이 저장되었습니다. 경로: {filePath}");
                }
                else
                {
                    statusLabel.Text = "저장 실패";
                    Console.WriteLine("저장 실패");
                }                
            }
            else
            {
                Console.WriteLine("파일 저장이 취소되었습니다.");
            }
        }

        private void SumMotionData(string fileName, int timeOffset, ref string[] sumLines)
        {
            string filePath = Path.Combine(motionDBpath, fileName);

            try
            {
                // 파일이 존재하는지 확인
                if (File.Exists(filePath))
                {
                    // CSV 파일의 모든 행 읽기
                    string[] lines = File.ReadAllLines(filePath);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lines[i]))
                        {
                            // 각 행을 ','로 나누어 열로 분리
                            string[] columns = lines[i].Split(',');

                            if (columns.Length > 0 && int.TryParse(columns[0], out int firstColumnValue))
                            {
                                firstColumnValue += timeOffset;
                                columns[0] = firstColumnValue.ToString();
                            }

                            lines[i] = string.Join(",", columns);
                        }
                    }

                    for (int i = 0; i < lines.Length; i++)
                    {
                        sumLines = AddLineToArray(ref sumLines, lines[i]);
                    }
                }
                else
                {
                    Console.WriteLine("파일이 존재하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }

        static string[] AddLineToArray(ref string[] array, string line)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 2] = line;
            return array;
        }

        private string AddAndConvertToString(string numStr1, string numStr2)
        {
            // numStr1과 numStr2를 숫자로 변환하여 더함
            if (int.TryParse(numStr1, out int num1) && int.TryParse(numStr2, out int num2))
            {
                int sum = num1 + num2;

                // 결과를 문자열로 변환하여 반환
                return sum.ToString();
            }
            else
            {
                // 변환에 실패하면 오류 메시지 반환 또는 다른 처리를 수행
                return "null";
            }
        }

        private void delayBtn_Click(object sender, EventArgs e)
        {
            int rowCount = motionGridView.Rows.Count;
            if (rowCount == 0)
            {
                motionGridView.Rows.Add(
                    0,              //모션 시작시간
                    delayTextBox.Text,    //모션 끝시간
                    "휴식",    //모션 이름
                    delayTextBox.Text     //모션 시간
                    );
            }
            else
            {
                DataGridViewRow aboveLastRow = motionGridView.Rows[rowCount - 1];//현재 마지막 행 값

                // "Column2" 열의 셀을 찾기
                DataGridViewCell cell = aboveLastRow.Cells["Column2"];

                if (cell != null && cell.Value != null)
                {
                    string above_Time = cell.Value.ToString();
                    // 나머지 코드
                    motionGridView.Rows.Add(
                    above_Time,     //이전 모션의 끝시간 -> 현재 추가된 모션의 시작시간
                    AddAndConvertToString(above_Time, delayTextBox.Text), //현재 모션 종료 시간         
                    "휴식",     //현재 모션의 이름.
                    delayTextBox.Text    //현재 모션의 시간            
                    );

                }
                else
                {
                    // "Column2" 열에 값이 없는 경우 처리
                    statusLabel.Text = "셀에 값이 없습니다.";
                }
            }



            statusLabel.Text = $"휴식 {delayTextBox.Text}ms를 목록에 추가합니다.";
        }


        #region 시나리오저장
        private void scenarioSave_Btn_Click(object sender, EventArgs e)
        {
            // DataGridView의 데이터를 CSV 파일로 저장
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Scen_.scen";
            saveFileDialog.Filter = "SCEN Files (*.scen)|*.scen";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolderPath = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                string newFolderPath = Path.Combine(selectedFolderPath, Path.GetFileNameWithoutExtension(saveFileDialog.FileName));
                
                try
                {
                    // 폴더를 생성합니다.
                    Directory.CreateDirectory(newFolderPath);

                    string scenFilePath = Path.Combine(newFolderPath, Path.GetFileNameWithoutExtension(saveFileDialog.FileName)+".scen");

                    using (StreamWriter sw = new StreamWriter(scenFilePath))
                    {
                        // 헤더 쓰기
                        foreach (DataGridViewColumn column in motionGridView.Columns)
                        {
                            sw.Write(column.HeaderText + ",");
                        }
                        sw.WriteLine();

                        // 데이터 쓰기
                        foreach (DataGridViewRow row in motionGridView.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                sw.Write(cell.Value + ",");
                            }
                            sw.WriteLine();
                        }
                    }

                    //시나리오에 사용한 유닛 저장
                    string unitFolderPath = Path.Combine(newFolderPath, "Unit");
                    try
                    {
                        // 폴더를 생성합니다.
                        Directory.CreateDirectory(unitFolderPath);
                        //MessageBox.Show($"New folder created: {newFolderPath}");

                        try
                        {
                            // DB 폴더를 대상 폴더로 복사
                            CopyDirectory(motionDBpath, unitFolderPath);

                            Console.WriteLine("Database folder copied successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show($"Error creating folder: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error creating folder: {ex.Message}");
                }
            }
        }


        static void CopyDirectory(string sourceDir, string targetDir)
        {
            // 대상 디렉터리가 존재하지 않으면 생성
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // 원본 디렉터리 안의 모든 파일을 대상 디렉터리로 복사
            foreach (string filePath in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(filePath);
                string targetFilePath = Path.Combine(targetDir, fileName);
                File.Copy(filePath, targetFilePath, true); // true는 이미 파일이 존재할 경우 덮어쓰기를 허용합니다.
            }

            // 원본 디렉터리 안의 모든 하위 디렉터리를 대상 디렉터리로 복사 (재귀적으로 호출)
            foreach (string subDirPath in Directory.GetDirectories(sourceDir))
            {
                string subDirName = Path.GetFileName(subDirPath);
                string targetSubDirPath = Path.Combine(targetDir, subDirName);
                CopyDirectory(subDirPath, targetSubDirPath);
            }
        }
        #endregion

        #region 시나리오불러오기
        private void scenarioOpen_Btn_Click(object sender, EventArgs e)
        {
            // CSV 파일에서 데이터를 읽어와서 DataGridView에 로드
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SCEN Files (*.scen)|*.scen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                motionGridView.Columns.Clear();
                fileDataGridView.Columns.Clear();
                InitializeDataGridView();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    // 헤더 읽기
                    string[] headers = sr.ReadLine().Split(',');

                    // 데이터 읽기
                    while (!sr.EndOfStream)
                    {
                        string[] values = sr.ReadLine().Split(',');
                        motionGridView.Rows.Add(values);
                    }
                }

                string selectedFolderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                string unitFolderPath = Path.Combine(selectedFolderPath, "Unit");
                try
                {
                    readUnitMotion(unitFolderPath);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error creating folder: {ex.Message}");
                }
                
            }
        }
        #endregion

       
    }
}

