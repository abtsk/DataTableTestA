Public Class Form1
    'データ保持
    Private dtForm As DataTable

    '列定義　キー値 Update/Insertのitem名として利用
    Private Enum CN
        LOT_NO
        PROD_NM
        KIND_NM
        CARTON_QTY
        MAX_CARTON_QTY
    End Enum

    '列定義　列名
    Private ReadOnly COL_SET As New Dictionary(Of String, String) From {
        {CN.LOT_NO, "ロットNo"},
        {CN.PROD_NM, "品名"},
        {CN.KIND_NM, "製品型名"},
        {CN.CARTON_QTY, "カートン数量"},
        {CN.MAX_CARTON_QTY, "MAXカートン数量"}
    }

    '使わない？　すべてロットNoキーで取得できるため、引数として渡す必要なし SelectTagで取得可
    Private Structure COL_NAME
        Public LOT_NO As String
        Public PROD_NM As String
        Public KIND_NM As String
        Public CARTON_QTY As String
        Public MAX_CARTON_QTY As String
    End Structure

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim cn As COL_NAME
        cn.LOT_NO = "BL11001"
        cn.PROD_NM = "R5JADSADS"
        cn.KIND_NM = "QALDE-282"
        cn.CARTON_QTY = "500"
        cn.MAX_CARTON_QTY = "2000"

        insertData(cn)

    End Sub

    Private Sub initialTable()

        '列追加
        For Each col As String In COL_SET.Values
            dtForm.Columns.Add(col, Type.GetType("System.String"))
        Next

    End Sub

    'test
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtForm = New DataTable

        initialTable()



    End Sub

    Private Sub insertData(ByVal col As COL_NAME)
        Dim row As DataRow
        row = dtForm.NewRow
        row(CN.LOT_NO) = col.LOT_NO                     'ロットNo
        row(CN.PROD_NM) = col.PROD_NM                   '品名
        row(CN.KIND_NM) = col.KIND_NM                   '製品外形
        row(CN.CARTON_QTY) = col.CARTON_QTY             'カートン数量
        row(CN.MAX_CARTON_QTY) = col.MAX_CARTON_QTY     'MAXカートン数量
        dtForm.Rows.Add(row)

        DataGridView1.DataSource = dtForm
    End Sub



End Class
