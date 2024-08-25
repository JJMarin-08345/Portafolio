/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Vista.productos;

import Controlador.ControladorGlobal;
import Controlador.ControladorProducto;
import Modelo.Producto;
import javax.swing.JOptionPane;

/**
 *
 * @author USUARIO
 */
public class nuevoProducto extends javax.swing.JInternalFrame {

    ControladorProducto controladorProducto;
    ControladorGlobal objGlobal;

    /**
     * Creates new form nuevoProducto
     */
    public nuevoProducto() {
        initComponents();
        controladorProducto = new ControladorProducto();
        objGlobal = new ControladorGlobal();
        //Le pasamos el controlador de login para obtener al usuario
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        lbl_Busqueda = new javax.swing.JLabel();
        lbl_descripcion = new javax.swing.JLabel();
        lbl_precio = new javax.swing.JLabel();
        txt_nombre = new javax.swing.JTextField();
        txt_descripcion = new javax.swing.JTextField();
        txt_id = new javax.swing.JTextField();
        txt_precio = new javax.swing.JTextField();
        btn_registrar_producto = new javax.swing.JButton();
        btn_limpiar = new javax.swing.JButton();
        lbl_nombre1 = new javax.swing.JLabel();
        btn_buscar = new javax.swing.JButton();
        btn_modificar = new javax.swing.JButton();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        btn_eliminar = new javax.swing.JButton();

        setClosable(true);
        setIconifiable(true);
        setMaximizable(true);

        jLabel1.setBackground(new java.awt.Color(153, 255, 255));
        jLabel1.setFont(new java.awt.Font("Dialog", 1, 24)); // NOI18N
        jLabel1.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabel1.setText("PRODUCTOS");

        jLabel2.setFont(new java.awt.Font("Dialog", 1, 14)); // NOI18N
        jLabel2.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabel2.setText("GESTIONAR PRODUCTOS");

        lbl_Busqueda.setFont(new java.awt.Font("Dialog", 1, 18)); // NOI18N
        lbl_Busqueda.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lbl_Busqueda.setText("ID");

        lbl_descripcion.setFont(new java.awt.Font("Dialog", 1, 18)); // NOI18N
        lbl_descripcion.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lbl_descripcion.setText("DESCRIPCIÓN");

        lbl_precio.setFont(new java.awt.Font("Dialog", 1, 18)); // NOI18N
        lbl_precio.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lbl_precio.setText("PRECIO");

        txt_nombre.setHorizontalAlignment(javax.swing.JTextField.CENTER);
        txt_nombre.setBorder(new javax.swing.border.SoftBevelBorder(javax.swing.border.BevelBorder.LOWERED));

        txt_descripcion.setHorizontalAlignment(javax.swing.JTextField.CENTER);
        txt_descripcion.setBorder(new javax.swing.border.SoftBevelBorder(javax.swing.border.BevelBorder.LOWERED));

        txt_id.setHorizontalAlignment(javax.swing.JTextField.CENTER);
        txt_id.setBorder(new javax.swing.border.SoftBevelBorder(javax.swing.border.BevelBorder.LOWERED));
        txt_id.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                txt_idActionPerformed(evt);
            }
        });
        txt_id.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txt_idKeyTyped(evt);
            }
        });

        txt_precio.setHorizontalAlignment(javax.swing.JTextField.CENTER);
        txt_precio.setBorder(new javax.swing.border.SoftBevelBorder(javax.swing.border.BevelBorder.LOWERED));
        txt_precio.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                txt_precioKeyTyped(evt);
            }
        });

        btn_registrar_producto.setFont(new java.awt.Font("Dialog", 1, 14)); // NOI18N
        btn_registrar_producto.setText("REGISTRAR");
        btn_registrar_producto.setBorder(new javax.swing.border.SoftBevelBorder(javax.swing.border.BevelBorder.RAISED));
        btn_registrar_producto.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_registrar_productoActionPerformed(evt);
            }
        });

        btn_limpiar.setFont(new java.awt.Font("Dialog", 1, 14)); // NOI18N
        btn_limpiar.setText("Limpiar");
        btn_limpiar.setBorder(new javax.swing.border.SoftBevelBorder(javax.swing.border.BevelBorder.RAISED));
        btn_limpiar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_limpiarActionPerformed(evt);
            }
        });

        lbl_nombre1.setFont(new java.awt.Font("Dialog", 1, 18)); // NOI18N
        lbl_nombre1.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        lbl_nombre1.setText("NOMBRE");

        btn_buscar.setText("Buscar");
        btn_buscar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_buscarActionPerformed(evt);
            }
        });

        btn_modificar.setText("Modificar");
        btn_modificar.setEnabled(false);
        btn_modificar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_modificarActionPerformed(evt);
            }
        });

        jLabel3.setFont(new java.awt.Font("Dialog", 1, 24)); // NOI18N
        jLabel3.setText("$");

        jLabel4.setText("Solo para busquedas");

        btn_eliminar.setText("Eliminar");
        btn_eliminar.setEnabled(false);
        btn_eliminar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_eliminarActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(6, 6, 6)
                        .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 626, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(6, 6, 6)
                        .addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 626, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(159, 159, 159)
                        .addComponent(lbl_Busqueda, javax.swing.GroupLayout.PREFERRED_SIZE, 60, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(158, 158, 158)
                        .addComponent(lbl_nombre1, javax.swing.GroupLayout.PREFERRED_SIZE, 125, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(45, 45, 45)
                        .addComponent(btn_buscar)
                        .addGap(15, 15, 15)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel4)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(3, 3, 3)
                                .addComponent(txt_id, javax.swing.GroupLayout.PREFERRED_SIZE, 110, javax.swing.GroupLayout.PREFERRED_SIZE)))
                        .addGap(128, 128, 128)
                        .addComponent(txt_nombre, javax.swing.GroupLayout.PREFERRED_SIZE, 154, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(127, 127, 127)
                        .addComponent(lbl_precio, javax.swing.GroupLayout.PREFERRED_SIZE, 125, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(124, 124, 124)
                        .addComponent(lbl_descripcion))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(100, 100, 100)
                        .addComponent(jLabel3, javax.swing.GroupLayout.PREFERRED_SIZE, 21, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(6, 6, 6)
                        .addComponent(txt_precio, javax.swing.GroupLayout.PREFERRED_SIZE, 125, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(124, 124, 124)
                        .addComponent(txt_descripcion, javax.swing.GroupLayout.PREFERRED_SIZE, 248, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap(49, Short.MAX_VALUE))
            .addGroup(layout.createSequentialGroup()
                .addGap(100, 100, 100)
                .addComponent(btn_registrar_producto)
                .addGap(47, 47, 47)
                .addComponent(btn_modificar)
                .addGap(52, 52, 52)
                .addComponent(btn_eliminar)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(btn_limpiar, javax.swing.GroupLayout.PREFERRED_SIZE, 86, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(69, 69, 69))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(14, 14, 14)
                .addComponent(jLabel1)
                .addGap(8, 8, 8)
                .addComponent(jLabel2)
                .addGap(37, 37, 37)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(lbl_Busqueda)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(2, 2, 2)
                        .addComponent(lbl_nombre1)))
                .addGap(4, 4, 4)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(12, 12, 12)
                        .addComponent(btn_buscar))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jLabel4)
                        .addGap(1, 1, 1)
                        .addComponent(txt_id, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(14, 14, 14)
                        .addComponent(txt_nombre, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addGap(29, 29, 29)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(lbl_precio)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(8, 8, 8)
                        .addComponent(lbl_descripcion)))
                .addGap(8, 8, 8)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jLabel3)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(9, 9, 9)
                        .addComponent(txt_precio, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(10, 10, 10)
                        .addComponent(txt_descripcion, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addGap(42, 42, 42)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_registrar_producto)
                    .addComponent(btn_modificar)
                    .addComponent(btn_eliminar)
                    .addComponent(btn_limpiar))
                .addContainerGap(38, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void txt_idActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txt_idActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_txt_idActionPerformed

    private void btn_registrar_productoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_registrar_productoActionPerformed
        String nombre = txt_nombre.getText();
        String descripcion = txt_descripcion.getText();

        try {
            double precio = Double.parseDouble(txt_precio.getText());
            Producto nuevoProducto = new Producto(0, nombre, descripcion, precio);
            // Llamar al controlador específico para el registro de productos
            if (controladorProducto.createProducto(nuevoProducto)) {
                limpiarCampos();
                // Limpiar los campos después del registro
            }
        } catch (NumberFormatException e) {
            JOptionPane.showMessageDialog(this, "Ingrese un valor numérico válido para Precio");
        }
    }//GEN-LAST:event_btn_registrar_productoActionPerformed

    private void btn_limpiarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_limpiarActionPerformed
        limpiarCampos();
    }//GEN-LAST:event_btn_limpiarActionPerformed

    private void btn_buscarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_buscarActionPerformed
        // TODO add your handling code here:
        if (!txt_id.getText().isEmpty()) {//Preguntamos si tiene algun valor el campo
            int ProductoId = Integer.parseInt("" + txt_id.getText());
            Producto pdFind = controladorProducto.obtenerProductoId(ProductoId);
            if (pdFind != null) { //Encontro un producto
                txt_id.setEnabled(false); // Como encontro algo, lo inhabilitamos y asi no modifique el id ingresado
                btn_modificar.setEnabled(true);
                btn_eliminar.setEnabled(true);//Habilitamos ambos botones
                btn_registrar_producto.setEnabled(false); //Inhabilitamos el boton de guardar por el momento
                txt_nombre.setText(pdFind.getNombre());
                txt_descripcion.setText(pdFind.getDescripcion());
                txt_precio.setText("" + pdFind.getPrecio());
            }
        }
    }//GEN-LAST:event_btn_buscarActionPerformed

    private void btn_modificarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_modificarActionPerformed
        // TODO add your handling code here:
        String nombre = txt_nombre.getText();
        String descripcion = txt_descripcion.getText();
        try {
            int productoId = Integer.parseInt("" + txt_id.getText());
            double precio = Double.parseDouble(txt_precio.getText());

            Producto nuevoProducto = new Producto(productoId, nombre, descripcion, precio);
            // Llamar al controlador específico para el registro de productos
            boolean isUpdate = controladorProducto.actualizarProducto(nuevoProducto);
            if (isUpdate) {
                limpiarCampos();
            }
        } catch (NumberFormatException e) {
            JOptionPane.showMessageDialog(this, "Ingrese un valor numérico válido para Precio o ID");
        }

    }//GEN-LAST:event_btn_modificarActionPerformed

    private void txt_idKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txt_idKeyTyped
        // TODO add your handling code here:
        // Para bloquear la entrada de numeros en el campo
        objGlobal.prohibirIngresoNumeros(evt);
    }//GEN-LAST:event_txt_idKeyTyped

    private void txt_precioKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_txt_precioKeyTyped
        // TODO add your handling code here:
        objGlobal.prohibirIngresoNumeros(evt);
    }//GEN-LAST:event_txt_precioKeyTyped

    private void btn_eliminarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_eliminarActionPerformed
        // TODO add your handling code here:
        int seleccion = JOptionPane.showConfirmDialog(this, "¿Desea eliminar el producto?", "Confirmacion", JOptionPane.YES_NO_OPTION);
        if (seleccion == JOptionPane.YES_OPTION) {
            int pr_id = Integer.parseInt("" + txt_id.getText());
            controladorProducto.eliminarProducto(pr_id);
        }
    }//GEN-LAST:event_btn_eliminarActionPerformed

    // Limpia los campos de texto
    private void limpiarCampos() {
        // Limpiar los campos de texto después de registrar un producto
        txt_nombre.setText("");
        txt_descripcion.setText("");
        txt_precio.setText("");
        txt_id.setText("");
        txt_id.setEnabled(true);
        btn_registrar_producto.setEnabled(true);
        btn_modificar.setEnabled(false);
        btn_eliminar.setEnabled(false);
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btn_buscar;
    private javax.swing.JButton btn_eliminar;
    public javax.swing.JButton btn_limpiar;
    private javax.swing.JButton btn_modificar;
    public javax.swing.JButton btn_registrar_producto;
    public javax.swing.JLabel jLabel1;
    public javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    public javax.swing.JLabel lbl_Busqueda;
    public javax.swing.JLabel lbl_descripcion;
    public javax.swing.JLabel lbl_nombre1;
    public javax.swing.JLabel lbl_precio;
    public javax.swing.JTextField txt_descripcion;
    public javax.swing.JTextField txt_id;
    public javax.swing.JTextField txt_nombre;
    public javax.swing.JTextField txt_precio;
    // End of variables declaration//GEN-END:variables
}
