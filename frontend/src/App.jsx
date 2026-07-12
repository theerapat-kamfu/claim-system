import { useEffect, useState, useMemo } from 'react';
import axios from 'axios';
import './App.css';

function App() {
  const [claims, setClaims] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5177/api/claims')
      .then(res => setClaims(res.data))
      .catch(err => console.error("Error fetching data:", err));
  }, []);

  // ปรับการคำนวณยอดรวมให้ใช้ claimAmount
  const totalAmount = useMemo(() => 
    claims.reduce((sum, c) => sum + (c.claimAmount ?? 0), 0), [claims]);

  return (
    <div className="page-container">
      <header className="header">
        <div>
          <h1 className="main-title">ระบบจัดการรายการเคลม</h1>
          <p className="sub-title">ข้อมูลล่าสุดจากระบบ Insurance API</p>
        </div>
        <div className="summary-card">
          <p>ยอดเงินเคลมรวมทั้งหมด</p>
          <h2 className="total-amount">฿ {totalAmount.toLocaleString()}</h2>
        </div>
      </header>

      <div className="table-wrapper">
        <table>
          <thead>
            <tr>
              <th>เลขที่เคลม</th>
              <th>รายละเอียด</th>
              <th>สถานะ</th>
              <th className="amount-col">จำนวนเงิน</th>
            </tr>
          </thead>
          <tbody>
            {claims.map(c => (
              <tr key={c.claimId}>
                <td>#{c.claimId}</td>
                <td className="title-cell">{c.description ?? "ไม่มีรายละเอียด"}</td>
                <td>
                  <span className={`badge status-${c.statusId ?? 0}`}>
                    {c.statusId === 1 ? 'อนุมัติแล้ว' : 'รอตรวจสอบ'}
                  </span>
                </td>
                <td className="amount-cell">฿ {(c.claimAmount ?? 0).toLocaleString(undefined, {minimumFractionDigits: 2})}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default App;