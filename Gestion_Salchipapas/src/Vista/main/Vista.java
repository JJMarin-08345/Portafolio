package Vista.main;

import Controlador.ControladorLogin;
import Modelo.Usuario;
import Vista.venta.frmVenta;
import javax.swing.JOptionPane;

public class Vista extends javax.swing.JFrame {

    public static ControladorLogin dataLogin;

    public Vista() {
        initComponents();
        setLocationRelativeTo(this);
        dataLogin = new ControladorLogin();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        txt_usuario = new javax.swing.JTextField();
        lbl_usuario = new javax.swing.JLabel();
        lbl_contrasena = new javax.swing.JLabel();
        jLabel1 = new javax.swing.JLabel();
        btn_ingresar = new javax.swing.JButton();
        txt_password = new javax.swing.JPasswordField();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        txt_usuario.setHorizontalAlignment(javax.swing.JTextField.CENTER);
        txt_usuario.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txt_usuarioKeyTyped(evt);
            }
        });

        lbl_usuario.setFont(new java.awt.Font("Dialog", 1, 14)); // NOI18N
        lbl_usuario.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lbl_usuario.setText("usuario");

        lbl_contrasena.setFont(new java.awt.Font("Dialog", 1, 14)); // NOI18N
        lbl_contrasena.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lbl_contrasena.setText("contraseña");

        jLabel1.setFont(new java.awt.Font("Dialog", 1, 14)); // NOI18N
        jLabel1.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabel1.setText("LOGIN");

        btn_ingresar.setText("INGRESAR");
        btn_ingresar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_ingresarActionPerformed(evt);
            }
        });

        txt_password.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txt_passwordKeyTyped(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(lbl_usuario, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(lbl_contrasena, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(138, 138, 138)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(txt_usuario, javax.swing.GroupLayout.PREFERRED_SIZE, 147, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(txt_password, javax.swing.GroupLayout.PREFERRED_SIZE, 146, javax.swing.GroupLayout.PREFERRED_SIZE)))
                            .addGroup(layout.createSequentialGroup()
                                .addGap(164, 164, 164)
                                .addComponent(btn_ingresar)))
                        .addGap(0, 146, Short.MAX_VALUE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(37, 37, 37)
                .addComponent(jLabel1)
                .addGap(18, 18, 18)
                .addComponent(lbl_usuario)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(txt_usuario, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(22, 22, 22)
                .addComponent(lbl_contrasena)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(txt_password, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(btn_ingresar)
                .addContainerGap(61, Short.MAX_VALUE))
        );

        btn_ingresar.getAccessibleContext().setAccessibleDescription("");

        pack();
    }// </editor-fold>//GEN-END:initComponents

    // Método para manejar el inicio de sesión al presionar el botón "Ingresar"

    private void btn_ingresarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_ingresarActionPerformed
        // TODO add your handling code here:
        String Usuario = txt_usuario.getText(); // Obtiene el nombre de usuario
        String contrasena = new String(txt_password.getPassword()); // Obtiene la contraseña
        Usuario user = new Usuario(Usuario, contrasena);

        // Verifica si las credenciales son válidas con el controlador de autenticación
        if (dataLogin.autenticar(user)) {
            frmVenta frmVenta = new frmVenta();
            frmVenta.setLocationRelativeTo(null);
            frmVenta.setVisible(true);
            this.setVisible(false);
        } else {
            JOptionPane.showMessageDialog(this, "Usuario o clave incorrecto", "Error en Autenticación", JOptionPane.CANCEL_OPTION);
        }

    }//GEN-LAST:event_btn_ingresarActionPerformed

    private void txt_usuarioKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txt_usuarioKeyTyped
        // TODO add your handling code here:
        pulsoEnter(evt);
    }//GEN-LAST:event_txt_usuarioKeyTyped

    private void txt_passwordKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txt_passwordKeyTyped
        // TODO add your handling code here:
        pulsoEnter(evt);
    }//GEN-LAST:event_txt_passwordKeyTyped

    private void pulsoEnter(java.awt.event.KeyEvent evt) {
        if (evt.getKeyChar() == 10) {
            btn_ingresar.doClick();
        }
    }

    public static void main(String args[]) {
        dataLogin = new ControladorLogin();
        // Hace visible la interfaz gráfica al ejecutar la aplicación
        if (dataLogin.cn.getConnection() != null) {
            java.awt.EventQueue.invokeLater(() -> {
                new Vista().setVisible(true);
            });
        } else {
            System.out.println("Error");
        }

    }

    // Variables declaration
    // End of variables declaration

    // Variables declaration - do not modify//GEN-BEGIN:variables
    public javax.swing.JButton btn_ingresar;
    public javax.swing.JLabel jLabel1;
    public javax.swing.JLabel lbl_contrasena;
    public javax.swing.JLabel lbl_usuario;
    private javax.swing.JPasswordField txt_password;
    public javax.swing.JTextField txt_usuario;
    // End of variables declaration//GEN-END:variables
}
