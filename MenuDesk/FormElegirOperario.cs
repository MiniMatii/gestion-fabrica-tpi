using Alemana.DTOs;

namespace MenuDesk
{
    /// <summary>Elegir el operario capaz que va a producir una orden.</summary>
    public class FormElegirOperario : Form
    {
        private readonly ComboBox _cmb = new() { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Top };

        public int IdOperario => _cmb.SelectedValue is int id ? id : 0;

        public FormElegirOperario(int idProd, List<OperarioOpcionDTO> operarios)
        {
            Text = $"Orden #{idProd}: asignar operario";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(380, 140);

            var lbl = new Label { Text = "Operario que va a producir:", Dock = DockStyle.Top, Height = 34, Padding = new Padding(12, 12, 0, 0) };
            _cmb.DisplayMember = nameof(OperarioOpcionDTO.NombreCompleto);
            _cmb.ValueMember = nameof(OperarioOpcionDTO.IdOperario);
            _cmb.DataSource = operarios;

            var ok = new Button { Text = "Confirmar", DialogResult = DialogResult.OK, Location = new Point(190, 92), Size = new Size(90, 30) };
            var cancelar = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(285, 92), Size = new Size(85, 30) };

            var cont = new Panel { Dock = DockStyle.Top, Height = 40, Padding = new Padding(12, 4, 12, 0) };
            cont.Controls.Add(_cmb);

            Controls.Add(cont);
            Controls.Add(lbl);
            Controls.Add(ok);
            Controls.Add(cancelar);
            AcceptButton = ok;
            CancelButton = cancelar;
        }
    }
}
