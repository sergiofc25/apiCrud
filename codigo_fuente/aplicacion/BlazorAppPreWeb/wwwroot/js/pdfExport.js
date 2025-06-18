function generatePdf(data) {
    try {
        const { title, tableData, totals } = data;
        console.log("📦 Parámetros recibidos:", data);

        const doc = new jsPDF({ orientation: 'p', unit: 'pt', format: 'a4' });
        const margin = 20;

        // 1) Título
        doc.setFont('helvetica', 'bold').setFontSize(16);
        doc.text(String(`Presupuesto: ${title}`), margin, margin + 20);

        // 2) Debug de tableData
        console.log("¿Es arreglo tableData?", Array.isArray(tableData), "length:", tableData.length);
        console.log("Primer elemento:", tableData[0]);

        // 3) Tabla manual head/body
        doc.autoTable({
            startY: margin + 40,
            margin: { left: margin, right: margin },

            head: [["Ítem", "Descripción", "Metrado", "Unid.", "P. Unit.", "Parcial"]],
            body: tableData.map(row => [
                row.item || "",
                row.nombre || "",
                row.metrado || "",
                row.unidad || "",
                row.precio || "",
                row.parcial || ""
            ]),

            tableWidth: 'auto',
            styles: {
                fontSize: 9,
                cellPadding: 4,
                overflow: 'linebreak',
                valign: 'middle'
            },
            headStyles: {
                fillColor: [51, 102, 153],
                textColor: 255,
                fontSize: 10
            }
        });


        // 4) Totales (igual que antes)
        let y = doc.lastAutoTable.finalY + 20;
        doc.setFont('helvetica', 'bold').setFontSize(12);
        doc.text("RESUMEN DE TOTALES", margin, y);

        const pageWidth = doc.internal.pageSize.getWidth();
        const addLine = (label, key) => {
            y += 15;
            doc.setFont('helvetica', 'bold').setFontSize(10);
            doc.text(String(label), margin, y);
            doc.setFont('helvetica', 'normal');
            doc.text(String(totals[key] ?? ""), pageWidth - margin, y, { align: 'right' });
        };

        addLine("Costo Directo:", 'costoDirecto');
        addLine(`Gastos Generales (${totals.gastosGeneralesPercent}%):`, 'gastosGenerales');
        addLine(`Utilidad (${totals.utilidadPercent}%):`, 'utilidad');
        addLine("Sub Total:", 'subTotal');
        addLine(`IGV (${totals.igvPercent}%):`, 'igv');
        addLine("TOTAL GENERAL:", 'total');

        // 5) Guardar
        const safeTitle = String(title).replace(/[^a-zA-Z0-9 ]/g, '').slice(0, 30);
        doc.save(`Presupuesto_${safeTitle}.pdf`);
        return true;
    }
    catch (err) {
        console.error("Error durante la generación del PDF:", err);
        throw err;
    }
}
