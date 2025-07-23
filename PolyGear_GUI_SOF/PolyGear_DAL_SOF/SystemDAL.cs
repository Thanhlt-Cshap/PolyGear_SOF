using PolyGear_UTIL_SOF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PolyGear_DAL_SOF
{
    public class SystemDAL
    {
        abstract public class BaseDAL<EntityType, KeyType>
        {
            abstract public void update(EntityType entity);
            abstract public List<EntityType> selectAll();
            abstract public EntityType selectById(KeyType id);
            abstract public List<EntityType> selectBySql(string sql, List<Object> args, CommandType cmdType = CommandType.Text);
            abstract public void insert(EntityType entity);
            public virtual void delete(KeyType id)
            {
                String sql = "DELETE FROM " + typeof(EntityType).Name + " WHERE Ma" + typeof(EntityType).Name + "=@1";
                List<Object> thamSo = new List<Object> { id };
                DBUtil.Update(sql, thamSo);
            }
        }
    }
}
