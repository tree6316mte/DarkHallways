﻿using System;
using UnityEngine;

namespace UnlockSystem
{
    [Serializable]
    public class usFPSMouseLook
    {
        #region Attributes

        [SerializeField] private bool clampVerticalRotation = true;
        [SerializeField] private Vector2 LimitX = new Vector2(-90, 90);

        private Vector2 Sensitivity = new Vector2(4, 4);

        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;

        #endregion

        #region PUBLIC

        public void InitMouseLook(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
        }

        public void LookRotationMouse(Transform character, Transform camera)
        {
            float yRot = Input.GetAxis("Mouse X") * Sensitivity.x;
            float xRot = Input.GetAxis("Mouse Y") * Sensitivity.y;

            m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

            if (clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

            character.localRotation = m_CharacterTargetRot;
            camera.localRotation = m_CameraTargetRot;
        }

        #endregion

        #region PRIVATE

        private Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, LimitX.x, LimitX.y);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

        #endregion
    }
}