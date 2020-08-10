using MediatR;
using Ocean.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Core.SeedWork
{
   public class BaseEntity<KeyT> where KeyT:class
    {
        int? _requestedHashCode;
        KeyT _Id;
        /// <summary>
        /// 主键
        /// </summary>
        public virtual KeyT Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; protected set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; protected set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; protected set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateBy { get; protected set; }

        #region 领域事件操作
        private List<Event> _domainEvents;
        public IReadOnlyCollection<Event> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(Event eventItem)
        {
            _domainEvents = _domainEvents ?? new List<Event>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(Event eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        #endregion


        public bool IsTransient()
        {
            return this.Id.GetType() == typeof(Int32);
        }

        /// <summary>
        /// 重写对象的相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity<KeyT>))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            BaseEntity<KeyT> item = (BaseEntity<KeyT>)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        /// <summary>
        /// 获取hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }

        /// <summary>
        /// 重写等于符号
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(BaseEntity<KeyT> left, BaseEntity<KeyT> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        /// <summary>
        /// 重写不等符号
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(BaseEntity<KeyT> left, BaseEntity<KeyT> right)
        {
            return !(left == right);
        }
    }
}
