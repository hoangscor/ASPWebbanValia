﻿using Thuchanhwebmvc.Models;
namespace Thuchanhwebmvc.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);

        TLoaiSp Update(TLoaiSp loaiSp);

        TLoaiSp Delete(String maloaiSp);

        TLoaiSp GetLoaiSp(String maloaiSp);

        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
