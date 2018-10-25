using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

using BusinessEntities;

namespace Data.database
{
    public class ProductoAdapter:Adapter
    {
        public List<Producto> getAll()
        {
            this.openConnection();
            List<Producto> productos = new List<Producto>();
            try { 
            SqlCommand sqlComm = new SqlCommand("SELECT * FROM productos", sqlconn);
            SqlDataReader sqldatar = sqlComm.ExecuteReader();

            while (sqldatar.Read())
            {
                    Producto p = new Producto();
                    p.ID = (int)sqldatar["id"];
                    p.Descripcion = (string)sqldatar["descripcion"];
                    p.Precio = (float)sqldatar["precio"];

                    productos.Add(p);
            }

                sqldatar.Close();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                this.closeConnection();
            }
            return productos;
        }

        public Producto getOne(int id)
        {
            this.openConnection();
            SqlCommand sqlc = new SqlCommand("SELECT * FROM productos WHERE id=@id", sqlconn);
            sqlc.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataReader sqldr = sqlc.ExecuteReader();
            Producto p = new Producto();
            if (sqldr.Read())
            {
                
                p.ID = id;
                p.Descripcion = (string)sqldr["descripcion"];
                p.Precio = (float)sqldr["precio"];
                
            }
            sqldr.Close();
            this.closeConnection();
            return p;


        }

        protected void Delete(int id)
        {
            openConnection();
            SqlCommand sqlc = new SqlCommand("DELETE productos WHERE id=@id", sqlconn);
            sqlc.Parameters.Add("@id", SqlDbType.Int).Value = id;
            sqlc.ExecuteNonQuery();
            closeConnection();
        }

        protected void Update(Producto p)
        {
            openConnection();
            SqlCommand sqlc = new SqlCommand("UPDATE productos SET descripcion=@desc, precio=@precio WHERE id=@id", sqlconn);
            sqlc.Parameters.Add("@id", SqlDbType.Int).Value = p.ID;
            sqlc.Parameters.Add("@desc", SqlDbType.VarChar,50).Value = p.Descripcion;
            sqlc.Parameters.Add("@precio", SqlDbType.Float).Value = p.Precio;
            sqlc.ExecuteNonQuery();
            closeConnection();
            


        }

        protected void Insert(Producto p)
        {
            openConnection();
            SqlCommand sqlc = new SqlCommand("INSERT INTO productos (descripcion,precio) values(@desc,@precio) SELECT @@identity", sqlconn);
            sqlc.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = p.Descripcion;
            sqlc.Parameters.Add("@precio", SqlDbType.Float).Value = p.Precio;
            p.ID = Decimal.ToInt32((decimal)sqlc.ExecuteScalar());
            closeConnection();
        }

        public void Save(Producto p)
        {
            if (p.State == BusinessEntities.BusinessEntities.States.Delete)
            {
                Delete(p.ID);
            }

            if (p.State == BusinessEntities.BusinessEntities.States.New)
            {
                Insert(p);
            }

            if (p.State == BusinessEntities.BusinessEntities.States.Modified)
            {
                Update(p);
            }

            p.State = BusinessEntities.BusinessEntities.States.Unmodified;
        }

    }
}
